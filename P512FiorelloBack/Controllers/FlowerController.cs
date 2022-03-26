using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
using P512FiorelloBack.Services;
using P512FiorelloBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Controllers
{
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMailService _mailService;

        public FlowerController(AppDbContext context, UserManager<User> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _context = context;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id,int categoryId)
        {
            Flower flower = _context.Flowers.Include(f => f.FlowerImages)
                .Include(f => f.Comments)
                .ThenInclude(c => c.User)
                .Include(f => f.FlowerCategories)
                .ThenInclude(fc => fc.Category).FirstOrDefault(f => f.Id == id);

            if (flower == null) return NotFound();
            ViewBag.Related = _context.Flowers.Where(f => f.FlowerCategories
                .FirstOrDefault(fc => fc.CategoryId == categoryId).
                CategoryId == categoryId && f.Id != flower.Id)
                .Include(f=>f.FlowerImages).Include(f=>f.FlowerCategories)
                 .ThenInclude(fc=>fc.Category).ToList();


            FlowerDetailViewModel model = new FlowerDetailViewModel
            {
                Flower = flower
            };

            return View(model);
        }

        public async Task<IActionResult> Search(string searchedStr)
        {
            if (string.IsNullOrWhiteSpace(searchedStr))
            {
                return PartialView("_SearchPartialView", new List<Flower>());
            }
            var flowers = await _context.Flowers.Where(f => f.Name.ToUpper().Contains(searchedStr.ToUpper())).ToListAsync();
            return PartialView("_SearchPartialView",flowers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddComment(int id, FlowerDetailViewModel model)
        {
            var flower = await _context.Flowers.Include(f => f.User).Include(f => f.FlowerImages).Include(f => f.Comments).ThenInclude(c => c.User)
                .Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).FirstOrDefaultAsync(f => f.Id == id);
            if (flower == null) return NotFound();

            if (!ModelState.IsValid) {
                model.Flower = flower;
                return View(model);
            }

            var comment = new Comment
            {
                Description = model.Comment.Description,
                UserId = _userManager.GetUserId(User),
                FlowerId = id
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            await _mailService.SendEmailAsync(new MailRequest
            {
                ToEmail = flower.User.Email,
                Subject = "New Comment",
                Body = $"new comment to your {flower.Name} flower: {comment.Description}"
            });

            return RedirectToAction(nameof(Detail), new { id });
        }


    }
}
