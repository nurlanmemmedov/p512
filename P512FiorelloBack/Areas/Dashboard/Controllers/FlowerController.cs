using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.Areas.Dashboard.ViewModels.Flower;
using P512FiorelloBack.Constants;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Extensions;
using P512FiorelloBack.Models;
using P512FiorelloBack.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = RoleConstants.Admin +"," + RoleConstants.Moderator)]
    public class FlowerController : Controller
    {

        private readonly AppDbContext _context;

        public FlowerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var flowers = await _context.Flowers.Select(f => new FlowerListViewModel
            {
                Id = f.Id,
                Name = f.Name,
                Price = f.Price,
                MainImage = f.MainImage
            }).ToListAsync();

            return View(flowers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var flower = await _context.Flowers.Include(f => f.FlowerImages)
                   .Include(f => f.Comments)
                   .ThenInclude(c => c.User)
                   .Include(f => f.FlowerCategories)
                   .ThenInclude(fc => fc.Category).FirstOrDefaultAsync(f => f.Id == id);

            if (flower == null) return NotFound();

            return View(flower);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            FlowerPostViewModel model = new FlowerPostViewModel
            {
                Campaigns = await _context.Campaigns.ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlowerPostViewModel model)
        {
            model.Campaigns = await _context.Campaigns.ToListAsync();
            model.Categories = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid) return View(model);

      

            //campaign
            var campaign = await _context.Campaigns.FindAsync(model.CampaignId);
            if (campaign == null)
            {
                ModelState.AddModelError(nameof(FlowerPostViewModel.CampaignId), "Choose a valid campaign");
                return View(model);
            }

            //categories
            List<FlowerCategory> categories = new List<FlowerCategory>();
            foreach (var categoryId in model.CategoryIds)
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if(category == null)
                {
                    ModelState.AddModelError(nameof(FlowerPostViewModel.CategoryIds), "Choose a valid category");
                    return View(model);
                }
                categories.Add(new FlowerCategory { CategoryId = categoryId });
            }

            //main image
            if (!model.MainImage.IsOkay())
            {
                ModelState.AddModelError(nameof(FlowerPostViewModel.MainImage), "There is a problem in your file");
                return View(model);
            }

            //flower images
            List<FlowerImage> images = new List<FlowerImage>();
            foreach (var image in model.Images)
            {
                if (!image.IsOkay())
                {
                    ModelState.AddModelError(nameof(FlowerPostViewModel.Images), $"There is a problem in your {image.FileName} file");
                    return View(model);
                }
                images.Add(new FlowerImage
                {
                    Name = FileUtils.Create(FileConstants.ImagePath, image)
                });
            }

            Flower flower = new Flower
            {
                Name = model.Name,
                Price = model.Price,
                Dimension = model.Dimension,
                DiscountPrice = model.Price - (model.Price * campaign.DiscountPercent / 100),
                Weight = model.Weight,
                SKUCode = model.SKUCode,
                Desc = model.Desc,
                CampaignId = model.CampaignId,
                MainImage = FileUtils.Create(FileConstants.ImagePath, model.MainImage),
                FlowerImages = images,
                FlowerCategories = categories
            };

            await _context.Flowers.AddAsync(flower);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));



        }



    }
}
