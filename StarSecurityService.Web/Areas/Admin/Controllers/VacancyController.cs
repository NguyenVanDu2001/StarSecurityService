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
    public class VacancyController : Controller
    {

        private readonly IBranchService _branchService;
        private readonly IServiceOfferService _serviceOfferService;
        private readonly IVacancyService _vacancyService;

        public VacancyController()
        {
            _branchService = new BranchService();
            _serviceOfferService = new ServiceOfferService();
            _vacancyService = new VacancyService();
        }


        // GET: Admin/Vacancy
        public ActionResult Index()
        {
            IEnumerable<Vacancy> items = new List<Vacancy>
            {

            };
            return View(items);
        }

        // GET: Admin/Vacancy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Vacancy/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Branch = new SelectList(await _branchService.GetAllBranchs(), "Id", "Name");
            ViewBag.Service = new SelectList(await _serviceOfferService.GetAll(), "Id", "Title");
            return View();
        }

        // POST: Admin/Vacancy/Create
        [HttpPost]
        public ActionResult Create(Vacancy vacancy)
        {
            try
            {
                _vacancyService.AddAsync(vacancy);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Vacancy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Vacancy/Edit/5
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

        // GET: Admin/Vacancy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
