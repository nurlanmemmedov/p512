using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
using P512FiorelloBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public NavViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Layout layout = await _context.Layouts.FirstOrDefaultAsync();

            var basketJson = Request.Cookies["basket"];
            List<BasketVm> basket;
            if (string.IsNullOrEmpty(basketJson))
            {
                basket = new List<BasketVm>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketVm>>(basketJson);
            }
            ViewBag.Count = basket.Sum(b => b.Count);
            ViewBag.TotalPrice = basket.Sum(b => (b.Flower.Price* b.Count));

            return View(new NavViewModel {Layout = layout, Basket = basket });
        }
    }
}
