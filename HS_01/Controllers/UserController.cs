using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HS_01.Models;
using HS_01.ViewModels;

namespace HS_01.Controllers
{
    public class UserController : Controller
    {
        HS0215DB db = new HS0215DB();
        [HttpGet]
        public ActionResult Qeydiyyat(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Qeydiyyat(User userModel,string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {

                {
                    if (db.Users.Any(u => u.Phone == userModel.Phone))
                    {
                        ViewBag.DuplicateMessage = "Bu nömrə ilə hesab var";
                        return View("Qeydiyyat", userModel);
                    }
                    if (userModel.Password == ConfirmPassword)
                    {
                        db.Users.Add(userModel);
                        db.SaveChanges();
                    }
                    ViewBag.SuccessMessage = "Qeydiyyatdan uğurla keçdiniz !";
                    return RedirectToAction("Login");
                }
            }
            ModelState.Clear();
            return View();

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userModel)
        {
            using (HS0215DB db = new HS0215DB())
            {
                var usr = db.Users.Single(u => u.Phone == userModel.Phone && u.Password == userModel.Password);
                if(usr != null)
                {
                    Session["UserID"] = usr;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.SuccessMessage = "Mobil nömrə və ya şifrə yanlışdı";
                }
                return View();
            }
        }
        public new ActionResult Profile()
        {
            var DefaultModel = new DefaultVIiewModel
            {
                uss = db.Users.Find(1),
            };
            return View(DefaultModel);
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
           return RedirectToAction("Index", "Home");
           
        }
    }
}