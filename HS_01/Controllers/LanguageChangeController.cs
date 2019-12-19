using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Controllers
{
    public class LanguageChangeController : Controller
    {
        // GET: LanguageChange
        public ActionResult Change(string lang)
        {
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("az");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("az");
            }
            Response.Cookies.Add(new HttpCookie("Language")
            {
                Value = lang
            });
            return RedirectToAction("Index", "Home");
        }
    }
}