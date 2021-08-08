using StarSecurityService.Application.Employees;
using StarSecurityService.Web.Areas.Admin.Model.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        public LoginController()
        {
            _employeeAppService = new EmployeeAppServices();
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            string name;

            if (TempData.ContainsKey("messageError"))
                name = TempData["messageError"].ToString(); // returns "Bill" 
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _employeeAppService.CheckLogin(input.EmailOrUserName, input.Password);
                if (user == null)
                {
                    TempData["messageError"] = $"Unknown username. Check again or try your email address.";
                    return RedirectToAction("index");
                }
                else
                {
                    Session["IdUser"] = user.Id;
                    Session["UserName"] = user.UserName;
                }
                return RedirectToAction("Index","Employee");
            }
            else
            {
                TempData["messageError"] = $"Unknown username. Check again or try your email address.";
            }
            return RedirectToAction("index");
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("index");
        }
    }
}
