using HS_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Areas.HSAdmin.Controllers
{
    public class AdminAccountController : Controller
    {
        // GET: HSAdmin/AdminAccount
        HS0215DB db = new HS0215DB();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin adm)
        {
            Admin selectAdmin = db.Admins.FirstOrDefault(ad => ad.Email == adm.Email);
            if (ModelState.IsValid)
            {
                if (selectAdmin != null)
                {
                    if (selectAdmin.Password == adm.Password)
                    {
                        Session["activeAdmin"] = selectAdmin;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Şifrə doğru deyil";
                    }
                }
                else
                {
                    ViewBag.Error = "Email doğru deyil";
                }
            }
            return View(selectAdmin);
        }
        public ActionResult Logout()
        {
            Session["activeAdmin"] = null;
            return RedirectToAction("Login", "AdminAccount");
        }
    }
}