using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.CategoryServiceoofers;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.CLientServices;
using StarSecurityService.Application.Histories;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Areas.Admin.Controllers;
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
        private readonly IClientEmployeeAppService _ClientEmployeesRepository;
        private readonly IServiceOfferService _serviceOfferService;
        private readonly IBrachAppService _branchService;
        private readonly IHistoryService _historyService;
        private readonly IShareHolderService _shareHolderService;
        private readonly IServiceOfferAppService _CategoryServiceOfferRepository;
        public HomeController()
        {
            db = new StarServiceDbContext();
            _clientAppServices = new ClientAppServices();
            _serviceOfferService = new ServiceOfferService();
            _branchService = new BranchAppService();
            _CategoryServiceOfferRepository = new CategoryServiceOfferService();
            _historyService = new HistoryService();
            _shareHolderService = new ShareHolderService();
            _ClientEmployeesRepository = new ClientEmployeeAppService();
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
            var db = await _branchService.GetAllByStatus();
            return View(db);
        }
        public ActionResult Divisions()
        {
            return View();
        }
        public async Task<ActionResult> Profesional(int id)
        {
          try {
                var model = new HomeAboutUs();
                model.ServiceOffersModel = ((await _serviceOfferService.GetAllByStatus()).Where(x => x.CategoryServiceOfferId == id).Select(x => new ServiceOffer
                {
                    Id = x.Id,
                    Title = x.Title,
                    Introduce = x.Introduce,
                    Description = x.Description,
                    Details = x.Details,
                    Url = x.Url,
                })?.AsEnumerable());
                model.ClientModel = await _clientAppServices.GetAll();
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new HomeAboutUs());
            }
        }

        public async Task<JsonResult> GetServiceOfferByCateId(int id)
        {
            // var res = new Response<List<ComboboxCommonDto>>();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> GetNavPartialServiceOffer()
        {
            var data = await _CategoryServiceOfferRepository.GetAll(status: true);

            return PartialView("~/Views/Shared/NavServiceOffer.cshtml", data);
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
    }
}