using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["IdUser"].Equals(""))
            {
                RouteValueDictionary route = new RouteValueDictionary(new { Controller = "Login", Action = "Index" });
                filterContext.Result = new RedirectToRouteResult(route);
                return;
            }
        }
    }
}