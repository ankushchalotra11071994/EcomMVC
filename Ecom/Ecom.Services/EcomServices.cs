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
        public void addcategory ( Category category)
        {
            ecom.Categories.Add(category);
            ecom.SaveChanges();
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
        public bool Deletebyid ( int id)
        {
            Category categoryobj = ecom.Categories.ToList()
               .Where(x => x.categoryId == id).FirstOrDefault();
           var check= ecom.Categories.Remove(categoryobj);
            ecom.SaveChanges();
            return true;
        }
    }
}
