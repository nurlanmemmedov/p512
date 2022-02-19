using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P512FiorelloBack.DAL;
using P512FiorelloBack.Models;
using P512FiorelloBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Controllers
{
    public class BasketController : Controller
    {

        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddToBasket(int id)
        {
            Flower flower = await _context.Flowers.FindAsync(id);
            if (flower == null) return RedirectToAction("Index", "Home");

            List<BasketVm> basket;

            var basketJson = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketJson))
            {
                basket  = new List<BasketVm>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketVm>>(basketJson);
            }

            var existFlower = basket.Find(b => b.Flower.Id == id);

            if (existFlower == null)
            {
                basket.Add(new BasketVm { Flower = flower });
            }
            else
            {
                existFlower.Count++;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetBasket()
        {
            var basketJson = Request.Cookies["basket"];
            List<BasketVm> basket = JsonConvert.DeserializeObject<List<BasketVm>>(basketJson);
            List<BasketVm> newBasket = new List<BasketVm>();

            foreach (var item in basket)
            {
                Flower flower = await _context.Flowers.FindAsync(item.Flower.Id);
                if (flower == null)
                {
                    continue;
                }
                newBasket.Add(new BasketVm { Flower = flower, Count = item.Count });
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(newBasket));
            return Content(JsonConvert.SerializeObject(newBasket));
        }

    }
}
