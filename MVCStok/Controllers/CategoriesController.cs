using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entities;

namespace MVCStok.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        Context c = new Context();

        public ActionResult Index()
        {
            var values = c.CategoriesList.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Categories k)
        {
            c.CategoriesList.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var categ = c.CategoriesList.Find(id);
            c.CategoriesList.Remove(categ);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getCategory(int id)
        {
            var categ = c.CategoriesList.Find(id);
            return View("getCategory", categ);
        }

        public ActionResult UpdateCategory(Categories k)
        {
            var categ = c.CategoriesList.Find(k.CategoryID);
            categ.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}