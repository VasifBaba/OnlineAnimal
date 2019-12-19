using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS_01.Areas.HSAdmin.Controllers
{
    public class AuthortionFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        [AuthortionFilter]
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            //Check for authorization
            if (HttpContext.Current.Session["activeAdmin"] == null)
            {
                filterContext.Result = new RedirectResult("~/HSAdmin/AdminAccount/Login");
            }

        }
    }
}