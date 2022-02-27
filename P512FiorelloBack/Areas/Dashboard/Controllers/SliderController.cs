using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
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

            if (!slider.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Slider.ImageFile), "File type is unsupported, please select image");
                return View();
            }
            if(slider.ImageFile.Length > 1024 * 1024)
            {
                ModelState.AddModelError(nameof(Slider.ImageFile), "File size cannot be greater than 1 mb");
                return View();
            }

            if (!slider.SignatureImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Slider.SignatureImageFile), "File type is unsupported, please select image");
                return View();
            }
            if (slider.SignatureImageFile.Length > 1024 * 1024)
            {
                ModelState.AddModelError(nameof(Slider.SignatureImageFile), "File size cannot be greater than 1 mb");
                return View();
            }

            // image starts
            var fileName = Guid.NewGuid() + slider.ImageFile.FileName;
            string wwwRootPath = _env.WebRootPath;
            var fullPath = Path.Combine(wwwRootPath, "assets", "images", fileName);

            FileStream stream = new FileStream(fullPath, FileMode.Create);
            await slider.ImageFile.CopyToAsync(stream);
            stream.Close();

            // signature starts
            var fileNameSign = Guid.NewGuid() + slider.SignatureImageFile.FileName;
            var fullPathSign = Path.Combine(wwwRootPath, "assets", "images", fileNameSign);

            FileStream streamSign = new FileStream(fullPathSign, FileMode.Create);
            await slider.SignatureImageFile.CopyToAsync(streamSign);
            stream.Close();

            slider.Image = fileName;
            slider.SignatureImage = fileNameSign;
            slider.RightIcon = "test";
            slider.LeftIcon = "test";

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

    }
}
