using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewComponents
{
    public class FlowerViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public FlowerViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<Flower> flowers = _context.Flowers.Include(f => f.FlowerCategories).ThenInclude(c => c.Category).ToList();
            return View(flowers);
        }
    }
}
