using Ecom.Database;
using Ecom.Entities;
using Ecom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        EcomServices services = new EcomServices();
        
        public ActionResult Index()
        {
            
            return View(services.GetCategories());
        }
   
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create( Category category)
        {
            services.addcategory(category); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            
            return View(services.GetCategorybyid(id));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {

            services.EditCategory(category);
             return RedirectToAction("Index");
        }
        
        
        public ActionResult Delete(int id)
        {

            services.DeleteProductid(id);
             return RedirectToAction("Index");
        }
    }
}