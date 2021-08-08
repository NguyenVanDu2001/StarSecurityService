using StarSecurityService.Application.Clients;
using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.Application.Employees;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Commons.Enums;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Commons;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IClientAppService _clientAppServices;
        private readonly IServiceOfferService _serviceOfferAppServices;
        public EmployeeController()
        {
            _employeeAppService = new EmployeeAppServices();
            _clientAppServices = new ClientAppServices();
            _serviceOfferAppServices = new ServiceOfferService();
        }
     
        // GET: Admin/Employee
        public async Task<ActionResult> Index()
        {
            var items = await _employeeAppService.GetAllEmployee();
            return View(items);
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<JsonResult> LoadComboboxClient()
        {
            var res = new Response<List<ComboboxCommonDto>>()
            {
                Data = await _clientAppServices.GetComboboxClient(),
                Message = "Success"
            };
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> LoadComboboxService()
        {
            var res = new Response<List<ComboboxCommonDto>>();
            try
            {
                res.Data = await _serviceOfferAppServices.GetComboboxServiceOffer();
                res.Message = "Success";
            }
            catch (System.Exception ex)
            {
                res.Message = "An error occurred";
                res.StatusCode = HttpStatusCode.OK;
                res.Status = StatusEnum.BadRequest;
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
}
