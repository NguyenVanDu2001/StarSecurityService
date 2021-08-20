using StarSecurityService.Application.Vacancys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IVacancyService _vacancyService;

        public HomeController()
        {
            _vacancyService = new VacancyService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public async Task<ActionResult> Career()
        {
            var items = await _vacancyService.GetAllByStatus();
            return View(items);
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Divisions()
        {
            return View();
        }
        public ActionResult Profesional()
        {
            return View();
        }
        public ActionResult Emiratisation()
        {
            return View();
        }
        public ActionResult BoardMember()
        {
            return View();
        }
        public ActionResult Whysss()
        {
            return View();
        }
        public ActionResult DubaiDivision()
        {
            return View();
        }
        public ActionResult Recruitment()
        {
            return View();
        }
        public ActionResult Supervision()
        {
            return View();
        }
        public ActionResult Training()
        {
            return View();
        }
        public ActionResult Facilities()
        {
            return View();
        }
    }
}