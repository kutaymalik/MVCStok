using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entities;

namespace MVCStok.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        Context c = new Context();
        public ActionResult Index()
        {
            var prods = c.ProductsList.Where(x=>x.Status==true).ToList();
            return View(prods);
        }

        [HttpGet]
        public ActionResult addProduct()
        {
            List<SelectListItem> var1 = (from x in c.CategoriesList.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.vr1 = var1;
            return View();
        }

        [HttpPost]
        public ActionResult addProduct(Products pr)
        {
            c.ProductsList.Add(pr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var del_id = c.ProductsList.Find(id);
            del_id.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> var1 = (from x in c.CategoriesList.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.vr1 = var1;

            var prod = c.ProductsList.Find(id);
            return View("GetProduct", prod);
        }

        public ActionResult UpdateProduct(Products p)
        {
            var prod = c.ProductsList.Find(p.ProductID);
            prod.SalePrice = p.SalePrice;
            prod.Status = p.Status;
            prod.Categoryid = p.Categoryid;
            prod.ProductBrand = p.ProductBrand;
            prod.PurchasePrice = p.PurchasePrice;
            prod.Stock = p.Stock;
            prod.ProductImage = p.ProductImage;
            prod.ProductName = p.ProductName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}