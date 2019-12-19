using HS_01.Models;
using HS_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Controllers
{
    public class AnimalController : Controller
    {
        HS0215DB db = new HS0215DB();

        public ActionResult Melumat(int? id)
        {
            if (id == null) return HttpNotFound();

            Elanlar ani = db.Elanlars.Find(id);

            if (ani == null) return HttpNotFound();

            var DefaultModel = new DefaultVIiewModel
            {
                elanFirst = ani,
               
                anima = db.Animals.Where(a => a.CategoryID == ani.Animal.CategoryID)
            };
            return View(DefaultModel);

        }
        public ActionResult Search(string q)
        {
            ViewBag.search = db.Animals.Where(ct => ct.Name.ToLower().Contains(q.ToLower())).ToList();
            return RedirectToAction("Search", "Animal");
        }
    }
}