﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var session = (Userlogin)HttpContext.Current.Session[Common.CommonConstants.USER_SESSION];
            //if (session == null)
            //{
            //    return false;
            //}

            //if (session.AccessName.Contains(this.RoleID) || session.GroupID == CommonConstants.ADMIN_GROUP)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //neu chua dang nhap
            if (HttpContext.Current.Session["IdUser"].Equals(""))
            {
                RouteValueDictionary route = new RouteValueDictionary(new { Controller = "Login", Action = "Index" });
                filterContext.Result = new RedirectToRouteResult(route);
                return;
            }
            // neu da dang nhap ma khong co quyen truy cap
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }

    }
}