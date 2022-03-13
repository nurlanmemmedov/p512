﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Models
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
