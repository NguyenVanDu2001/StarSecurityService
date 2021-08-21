using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.CategoryServiceoofers;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Areas.Admin.Controllers;
using StarSecurityService.Web.Helpers;
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
        private StarServiceDbContext db;
        private readonly IClientAppService _clientAppServices;
        private readonly IServiceOfferService _serviceOfferService;
        private readonly IBrachAppService _branchService;
        private readonly IServiceOfferAppService _CategoryServiceOfferRepository;
        public HomeController()
        {
            db = new StarServiceDbContext();
            _clientAppServices = new ClientAppServices();
            _serviceOfferService = new ServiceOfferService();
            _branchService = new BranchAppService();
            _CategoryServiceOfferRepository = new CategoryServiceOfferService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        { 
            return View();
        }
        public ActionResult Career()
        {
            return View();
        }
        public async Task<ActionResult> ContactUs()
        {
            var db = await _branchService.GetAllByStatus();
            return View(db);
        }
        public ActionResult Divisions()
        {
            return View();
        }
        public async Task<ActionResult> Profesional()
        {
            var data = await _CategoryServiceOfferRepository.GetAll();
            return View(data);
        }
        public async Task<JsonResult> GetServiceOfferByCateId(int id)
        {
           // var res = new Response<List<ComboboxCommonDto>>();
            return Json(1,JsonRequestBehavior.AllowGet);
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
            if (data != null)
            {
                var thumb = GetControllerHelper.GetThumb(data.Url);
                ViewBag.thumbData = thumb;
            }
            else
            {
                return RedirectToAction("Index");
            }
            ViewBag.serviceData = data;
            return View();
        }
    }
}