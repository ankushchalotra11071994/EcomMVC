using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entities
{
   public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public Product product { get; set; }
    }
}
