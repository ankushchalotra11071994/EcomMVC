using Ecom.Entities;
using Ecom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom.Web.Controllers
{
    public class ProductController : Controller
    {
        EcomServices ecomServices = new EcomServices();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            return PartialView(ecomServices.GetProducts());
        }
        [HttpPost]
        public ActionResult ProductList(string search)
        {
            
          return View(ecomServices.Getproductbyid(search));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            ecomServices.addproduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {

            return PartialView(ecomServices.Getproductbyid(id));
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            ecomServices.Editproduct(product);
            return RedirectToAction("Index");
        }
           public ActionResult Delete(int id)
        {

            ecomServices.Deletebyid(id);
            return RedirectToAction("Index");
        }

    }
}