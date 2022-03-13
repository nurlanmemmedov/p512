using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.ViewModels
{
    public class CommentPostViewModel
    {

        [Required, MaxLength(500), MinLength(10)]
        public string Description { get; set; }
    }
}
