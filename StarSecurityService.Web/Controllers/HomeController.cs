using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.Histories;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Helpers;
using StarSecurityService.Web.Models;
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
        private readonly IHistoryService _historyService;
        private readonly IShareHolderService _shareHolderService;
        public HomeController()
        {
            db = new StarServiceDbContext();
            _clientAppServices = new ClientAppServices();
            _serviceOfferService = new ServiceOfferService();
            _branchService = new BranchAppService();
            _historyService = new HistoryService();
            _shareHolderService = new ShareHolderService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AboutUs()
        {
            var model = new HomeAboutUs();
            model.HistoryModel = await _historyService.GetAll();
            model.ShareHolderModel = await _shareHolderService.GetAll();
            return View(model);
        }
        public ActionResult Career()
        {
            return View();
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