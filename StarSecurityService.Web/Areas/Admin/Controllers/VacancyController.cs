using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.Application.Vacancys;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class VacancyController : Controller
    {

        private readonly IBrachAppService _branchService;
        private readonly IServiceOfferService _serviceOfferService;
        private readonly IVacancyService _vacancyService;

        public VacancyController()
        {
            _branchService = new BranchAppService();
            _serviceOfferService = new ServiceOfferService();
            _vacancyService = new VacancyService();
        }


        // GET: Admin/Vacancy
        public async Task<ActionResult> Index()
        {
            var items = await _vacancyService.GetAll();
            return View(items);
        }

        // GET: Admin/Vacancy/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Branch = await _branchService.GetAllBranchs();
            ViewBag.Service = await _serviceOfferService.GetAll();
            return View();
        }

        // POST: Admin/Vacancy/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Vacancy vacancy)
        {
            try
            {
                vacancy.UpdateBy = Int32.Parse(Session["IdUser"].ToString());
                _vacancyService.AddAsync(vacancy);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Vacancy/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Branch = await _branchService.GetAllBranchs();
            ViewBag.Service = await _serviceOfferService.GetAll();
            var db = await _vacancyService.FirstOrDefaultAsync(id);
            return View(db);
        }

        // POST: Admin/Vacancy/Edit/5
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> Edit(int id, Vacancy vacancy)
        {
            try
            {
                vacancy.UpdateBy = Int32.Parse(Session["IdUser"].ToString());
                _vacancyService.UpdateAsync(vacancy);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Vacancy/Delete/5
        public ActionResult Delete(int id)
        {
            _vacancyService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/Vacancy/Delete/5
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
    }
}
