using P512FiorelloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewModels
{
    public class FlowerDetailViewModel
    {
        //get
        public Flower Flower { get; set; }

        //post
        public CommentPostViewModel Comment { get; set; }
    }
}
