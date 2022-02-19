using P512FiorelloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewModels
{
    public class BasketVm
    {
        public Flower Flower { get; set; }
        public int Count { get; set; } = 1;
    }
}
