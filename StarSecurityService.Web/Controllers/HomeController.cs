using StarSecurityService.Application.Clients;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.EntityFramework.Data;
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
        public HomeController()
        {
            db = new StarServiceDbContext();
            _clientAppServices = new ClientAppServices();
            _serviceOfferService = new ServiceOfferService();
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
            var data = await _serviceOfferService.GetAll();
            return View(data);
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
        public async Task<ActionResult> Emiratisation() 
        {
            ViewBag.clientData = await _clientAppServices.FirstOrDefaultAsync(1);
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
        public async Task<ActionResult> Facilities()
        {
            ViewBag.serviceData = await _serviceOfferService.FirstOrDefaultAsync(1);
            var data = await _serviceOfferService.GetAll();
            return View(data);
        }
    }
}