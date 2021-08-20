using StarSecurityService.Application.Vacancys;
﻿using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StarSecurityService.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IVacancyService _vacancyService;

        private StarServiceDbContext db;
        private readonly IClientAppService _clientAppServices;
        private readonly IServiceOfferService _serviceOfferService;
        private readonly IBrachAppService _branchService;

        public HomeController()
        {
            db = new StarServiceDbContext();
            _clientAppServices = new ClientAppServices();
            _serviceOfferService = new ServiceOfferService();
            _branchService = new BranchAppService();
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
        public async Task<ActionResult> ContactUs()
        {
            var db = await _branchService.GetAllBranchs();
            return View(db);
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
        public async Task<ActionResult> Facilities()
        {
            var data = db.ServiceOffers.FirstOrDefault();
            var thumb = GetControllerHelper.GetThumb(data.Url);
            ViewBag.serviceData = data;
            ViewBag.thumbData = thumb;
            return View();
        }

    }
}