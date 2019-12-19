using HS_01.Models;
using HS_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Controllers
{
    public class HomeController : Controller
    {
        HS0215DB db = new HS0215DB();

        public ActionResult Index(int? id)
        {

            var DefaultModel = new DefaultVIiewModel
            {
                ctg = db.Categories.ToList(),
                ani = db.Animals.ToList(),
                ban = db.Banners.ToList()

            };
            return View(DefaultModel);
        }

        public ActionResult Qeydiyyat()
        {
            var DefaultModel = new DefaultVIiewModel
            {
                ctg = db.Categories.ToList(),
                ani = db.Animals.ToList(),
                cty = db.Cities.ToList(),
                uss = db.Users.Find(1),
                aniDetail = db.Animals.FirstOrDefault()
            };
            return View(DefaultModel);
        }

       
        public ActionResult ElanYerlesdirme()
        {
            if (Session["UserID"]==null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var DefaultModel = new DefaultVIiewModel
                {
                    ctg = db.Categories.ToList(),
                    ani = db.Animals.ToList(),
                    cty = db.Cities.ToList()
                };
                return View(DefaultModel);
            }
     
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ElanYerlesdirme(Animal ani)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath($"/Uploads/{file.FileName}"));
                }
            }

            User userId = Session["UserID"] as User;
            var DefaultModel = new DefaultVIiewModel
            {
                ctg = db.Categories.ToList(),
                ani = db.Animals.ToList(),
                cty = db.Cities.ToList(),

            };
            Animal newAnimal = db.Animals.Add(ani);
            //db.SaveChanges();
            db.Elanlars.Add(new Elanlar
            {
                UserId = userId.ID,
                AnimalId=newAnimal.ID,
                categoryId=newAnimal.CategoryID,
                CreatedDate=DateTime.Now,
                EndDate= DateTime.Today.AddMonths(1)    
            });
            //db.SaveChanges();
            return Json(true);
        }

        public ActionResult Choose(int? aid)
        {
            var DefaultModel = new DefaultVIiewModel
            {
                anima = db.Animals.Where(a => a.ID == (aid != null ? aid : a.ID)),
                ctg = db.Categories.OrderByDescending(a=>a.Animals.Count).Take(5).ToList()
            };
            return View(DefaultModel);
        }
        public ActionResult Search(string q)
        {
            ViewBag.search = db.Animals.Where(ct => ct.Name.ToLower().Contains(q.ToLower())).ToList();
            return View();
        }

    }
}