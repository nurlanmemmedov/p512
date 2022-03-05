using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.Areas.Dashboard.ViewModels;
using P512FiorelloBack.Constants;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Extensions;
using P512FiorelloBack.Models;
using P512FiorelloBack.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (!slider.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(Slider.ImageFile), "File type is unsupported, please select image");
                return View();
            }
            if (!slider.SignatureImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(Slider.SignatureImageFile), "File type is unsupported, please select image");
                return View();
            }
          

            int a = 5;

            #region uzunkod
            //string wwwRootPath = _env.WebRootPath;

            //// image starts
            //var folderPath = Path.Combine(wwwRootPath, "assets", "img");

            //FileStream stream = new FileStream(fullPath, FileMode.Create);
            //await slider.ImageFile.CopyToAsync(stream);
            //stream.Close();

            // signature starts
            //var fileNameSign = Guid.NewGuid() + slider.SignatureImageFile.FileName;
            //var fullPathSign = Path.Combine(wwwRootPath, "assets", "images", fileNameSign);

            //FileStream streamSign = new FileStream(fullPathSign, FileMode.Create);
            //await slider.SignatureImageFile.CopyToAsync(streamSign);
            //streamSign.Close();

            #endregion
            //var folderPath = Path.Combine(_env.WebRootPath, "assets", "images");

            slider.Image = FileUtils.Create(FileConstants.ImagePath, slider.ImageFile);
            slider.SignatureImage = FileUtils.Create(FileConstants.ImagePath, slider.SignatureImageFile);
            slider.RightIcon = "test";
            slider.LeftIcon = "test";

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            FileUtils.Delete(Path.Combine(FileConstants.ImagePath, slider.Image));
            FileUtils.Delete(Path.Combine(FileConstants.ImagePath, slider.SignatureImage));
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(CreateMultipleSliderVm model)
        {
            if (!ModelState.IsValid) return View();

            byte order = 1;
            foreach (var image in model.Images)
            {
                if (!image.IsOkay())
                {
                    ModelState.AddModelError(nameof(Slider.ImageFile), $"There is problem in your image named {image.FileName}");
                    return View();
                }

                Slider slider = new Slider
                {
                    Title = model.Title,
                    Desc = model.Desc,
                    SignatureImage = FileUtils.Create(FileConstants.ImagePath, model.SignatureImageFile),
                    Image = FileUtils.Create(FileConstants.ImagePath, image),
                    Order = order++,
                    LeftIcon = "test",
                    RightIcon = "test"
                };

                await _context.Sliders.AddAsync(slider);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}
