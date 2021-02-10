using Ecom.Database;
using Ecom.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Services
{
   
  public class EcomServices
    {
        EcomContext ecom = new EcomContext();
        public EcomServices()
        {

        }

        public  List<Category> GetCategories()
        {
            return ecom.Categories.ToList();
        }

        public List<Product> GetProducts()
        {
            return ecom.Products.ToList();
        }
        public void addcategory ( Category category)
        {
            ecom.Categories.Add(category);
            ecom.SaveChanges();
        }  
        public void addproduct ( Product product)
        {
            ecom.Products.Add(product);
            ecom.SaveChanges();
        }
        public void Editproduct(Product product)
        {
            //ecom.Entry(category).State=EntityState.Modified;
            //ecom.SaveChanges();

            Product categoryobj = ecom.Products.ToList()
                .Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            if (categoryobj != null)
            {
                categoryobj.ProductId = (int)product.ProductId;
                categoryobj.Name = product.Name;
                categoryobj.Description = product.Description;
                categoryobj.Categoryid = product.Categoryid;
                ecom.SaveChanges();
            }
        } 
        public void EditCategory(Category category)
        {
            //ecom.Entry(category).State=EntityState.Modified;
            //ecom.SaveChanges();

            Category categoryobj = ecom.Categories.ToList()
                .Where(x => x.categoryId == category.categoryId).FirstOrDefault();
            if (categoryobj != null)
            {
                categoryobj.categoryId = (int)category.categoryId;
                categoryobj.Name = category.Name;
                categoryobj.Description = category.Description;
                ecom.SaveChanges();
            }
        }
        public Category GetCategorybyid ( int id)
        {
          return  ecom.Categories.Find(id);
        } 
        public Product  Getproductbyid ( int id)
        {
          return  ecom.Products.Find(id);
        }
        public  List<Product> Getproductbyid ( string name)
        {

          return  ecom.Products.Where(x => x.Name.Contains(name)).ToList();


  }
        public bool DeleteProductid ( int id)
        {
            Product categoryobj = ecom.Products.ToList()
               .Where(x => x.ProductId == id).FirstOrDefault();
           var check= ecom.Products.Remove(categoryobj);
            ecom.SaveChanges();
            return true;
        }
         public bool Deletebyid ( int id)
        {
            Product categoryobj = ecom.Products.ToList()
               .Where(x => x.ProductId == id).FirstOrDefault();
           var check= ecom.Products.Remove(categoryobj);
            ecom.SaveChanges();
            return true;
        }

    }
}
