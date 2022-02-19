using P512FiorelloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewModels
{
    public class NavViewModel
    {
        public Layout Layout { get; set; }
        public List<BasketVm> Basket { get; set; }
    }
}
