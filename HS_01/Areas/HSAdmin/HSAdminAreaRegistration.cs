using System.Web.Mvc;

namespace HS_01.Areas.HSAdmin
{
    public class HSAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HSAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HSAdmin_default",
                "HSAdmin/{controller}/{action}/{id}",
                new {controller="Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "HS_01.Areas.HSAdmin.Controllers" }
            );
        }
    }
}