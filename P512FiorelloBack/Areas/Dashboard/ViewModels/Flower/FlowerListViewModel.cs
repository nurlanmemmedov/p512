using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.ViewModels.Flower
{
    public class FlowerListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string MainImage { get; set; }
    }
}
