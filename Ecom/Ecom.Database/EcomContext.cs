using Ecom.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Database
{
   public class EcomContext:DbContext
    {
        public EcomContext():base("sqlServer")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }  
        public DbSet<Thumbnail> Thumbnails { get; set; }

    }
}
