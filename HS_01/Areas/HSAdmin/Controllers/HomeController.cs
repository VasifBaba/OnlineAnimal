using HS_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Areas.HSAdmin.Controllers
{
    [AuthortionFilter]
    public class HomeController : Controller 
    {
        HS0215DB db = new HS0215DB();
        // GET: HSAdmin/Home
        public ActionResult Index()
        {
            if (Session["activeAdmin"] == null)
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            return View();
        }
        public ActionResult Search(string q)
        {
            ViewBag.search = db.Animals.Where(ct => ct.Name.ToLower().Contains(q.ToLower())).ToList();
            return View();
        }
    }
}
