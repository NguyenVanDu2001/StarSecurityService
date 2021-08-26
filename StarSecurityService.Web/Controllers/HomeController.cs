using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.CategoryServiceoofers;
using StarSecurityService.Application.Vacancys;
﻿using StarSecurityService.Application.Branchs;
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
using System.Web.Mvc;
using System.Collections.Generic;

namespace StarSecurityService.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IVacancyService _vacancyService;

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
            _vacancyService = new VacancyService();

            _ClientEmployeesRepository = new ClientEmployeeAppService();
        }

        public async Task<ActionResult> Index()
        {
            var model = new HomeIndexModel()
            {
                HistoryModel = (await _historyService.GetAll()).FirstOrDefault(),
                CategoryServiceOfferModel = await _CategoryServiceOfferRepository.GetAll(),
                Branchs =( await _branchService.GetAllByStatus()).ToList(),
            };
            return View(model);
        }

        public async Task<ActionResult> AboutUs()
        {
            var model = new HomeAboutUs();
            model.HistoryModel = await _historyService.GetAll();
            model.ShareHolderModel = await _shareHolderService.GetAll();
            return View(model);
        }

        public async Task<ActionResult> Career( string filter = "")
        {
            var items = await _vacancyService.GetAllByStatus(filter);
            return View(items);
        }


        public async Task<ActionResult> JobDetails(int id)
        {
            var items = await _vacancyService.FirstOrDefaultAsync(id);
            ViewBag.Branch = await _branchService.FirstOrDefaultAsync(items.BranchId);
            ViewBag.Service = await _serviceOfferService.FirstOrDefaultAsync(items.ServiceOfferId);
            string[] image = ViewBag.Service.Url.Split(' ');
            List<string> path = new List<string>();
            foreach (string img in image)
            {
                path.Add(img);
            }
            ViewBag.Image = path;
            return View(items);
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
        public async Task<ActionResult> Profesional(int id , int? serivceOfferId = 0)
        {
          try {
                var model = new HomeAboutUs();
                    var listRespomse = new List<ServiceOfferCategoryOuput>();  
                    var listServiceOfferData = ((await _serviceOfferService.GetAllByStatus()).Where(x => x.CategoryServiceOfferId == id)?.ToList());
                if (serivceOfferId.GetValueOrDefault(1) > 0)
                {
                    foreach (var item in listServiceOfferData)
                    {
                        var serviceoffer = new ServiceOfferCategoryOuput
                        {
                            Title = item.Title,
                            Introduce = item.Introduce,
                            Description = item.Description,
                            Details = item.Details,
                            Url = item.Url,
                            CategoryServiceOfferId = item.CategoryServiceOfferId.HasValue ? item.CategoryServiceOfferId.Value : 0,
                            Id = item.Id,
                            isSelected = serivceOfferId == item.Id ? true : false,
                        };
                        if (item.ClientEmployees?.Any() == true)
                        {

                            serviceoffer.ClientModel = item.ClientEmployees?.Select(z => new Client
                            {
                                Name = z.Clients.Name,
                                Phone = z.Clients.Phone,
                                Address = z.Clients.Address
                            })?.AsEnumerable();
                        }
                        listRespomse.Add(serviceoffer);
                    }
                    model.ServiceOffersModel = listRespomse;

                }
                else
                {
                    foreach (var item in listServiceOfferData)
                    {
                        var serviceoffer = new ServiceOfferCategoryOuput
                        {
                            Title = item.Title,
                            Introduce = item.Introduce,
                            Description = item.Description,
                            Details = item.Details,
                            Url = item.Url,
                            CategoryServiceOfferId = item.CategoryServiceOfferId.HasValue ? item.CategoryServiceOfferId.Value : 0,
                            Id = item.Id,
                            isSelected = serivceOfferId == item.Id ? true : false,
                        };
                        if (item.ClientEmployees?.Any() == true)
                        {

                            serviceoffer.ClientModel = item.ClientEmployees?.Select(z => new Client
                            {
                                Name = z.Clients.Name,
                                Phone = z.Clients.Phone,
                                Address = z.Clients.Address
                            })?.AsEnumerable();
                        }
                        listRespomse.Add(serviceoffer);
                    }
                model.ServiceOffersModel = listRespomse;

                    model.ServiceOffersModel.FirstOrDefault().isSelected = true;
                }
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