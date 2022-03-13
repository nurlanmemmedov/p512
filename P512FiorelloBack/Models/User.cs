using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Comment> Comments { get; set; }
    }
}
