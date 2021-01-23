using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entities
{
   public class Product
    { 
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }  
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int thumbnailid { get; set; }
         public int Categoryid { get; set; }


    }
}
