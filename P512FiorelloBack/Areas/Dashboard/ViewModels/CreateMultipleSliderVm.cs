using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Areas.Dashboard.ViewModels
{
    public class CreateMultipleSliderVm
    {
        [Required]
        [StringLength(maximumLength: 300)]
        public string Desc { get; set; }

        [Required]
        [StringLength(maximumLength: 170)]
        public string Title { get; set; }

        [NotMapped]
        [Required]
        public IFormFile SignatureImageFile { get; set; }

        [Required]
        public IFormFile[] Images { get; set; }


    }
}
