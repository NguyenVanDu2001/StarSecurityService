using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            IAsyncRepository<GroupUser> _grUsed = new EfRepository<GroupUser>(new StarServiceDbContext());
            IAsyncRepository<GroupPermesstion> _grPermis = new EfRepository<GroupPermesstion>(new StarServiceDbContext());
            IAsyncRepository<Employyee> _grEm= new EfRepository<Employyee>(new StarServiceDbContext());
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
            if (HttpContext.Current.Session["IdUser"] == null)
            {
                return false;
            }
            var em =  _grEm.GetById((int)HttpContext.Current.Session["IdUser"]);
            GroupUser groupUser =  _grUsed.GetById(em.GroupId.Value);
            if (groupUser.isAdmin == true) // kiểm tra nhóm quyền có phải nhóm quản trị hay ko
            {
                return true;
            }
            string controller = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller");
            string action = httpContext.Request.RequestContext.RouteData.GetRequiredString("action");

            string permistionId = controller + "Controller-" + action;
            // kiểm tra quyền đã được gán cho chưa
            var isPermisstion = ( _grPermis.GetAll()).Any(x => x.GroupId == em.GroupId && x.PermisstionId == permistionId);
            if (isPermisstion)
            {
                return true;
            }

            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //neu chua dang nhap
            if (HttpContext.Current.Session["IdUser"] == null)
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