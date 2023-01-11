using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entities;

namespace MVCStok.Controllers
{
    public class CurrentAccountController : Controller
    {
        // GET: CurrentAccount

        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.CurrentAccountList.Where(x=>x.Durum==true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCurrentAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCurrentAccount(CurrentAccount p)
        {
            if (!ModelState.IsValid)
            {
                return View("getCurrentAccount");
            }
            p.Durum = true;
            c.CurrentAccountList.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteCurrentAccount(int id)
        {
            var cr = c.CurrentAccountList.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getCurrentAccount(int id)
        {
            var ca = c.CurrentAccountList.Find(id);
            return View("getCurrentAccount", ca);
        }

        public ActionResult UpdateCurrentAccount(CurrentAccount p)
        {
            if (!ModelState.IsValid)
            {
                return View("getCurrentAccount");
            }
            var ca = c.CurrentAccountList.Find(p.CurrentAccountID);
            ca.CurrentAccountName = p.CurrentAccountName;
            ca.CurrentAccountLastname = p.CurrentAccountLastname;
            ca.CurrentAccountCity = p.CurrentAccountCity;
            ca.CurrentAccountMail = p.CurrentAccountMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CustomerSales(int id)
        {

            var cs = c.SaleActList.Where(x => x.CurrentAccountID == id).ToList();
            var cr = c.CurrentAccountList.Where(x => x.CurrentAccountID == id).Select(y => y.CurrentAccountName + " " + y.CurrentAccountLastname).FirstOrDefault();
            ViewBag.CurrentAccount = cr;
            return View(cs);
        }


    }
}