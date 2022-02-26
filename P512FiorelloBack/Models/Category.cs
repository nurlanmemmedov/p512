using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bosh qoyma qardas")]
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage ="100den artiq olmaz qardash")]
        public string Description { get; set; }
        public List<FlowerCategory> FlowerCategories { get; set; }
    }
}
