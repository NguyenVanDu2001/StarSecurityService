using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class VacancyController : Controller
    {
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
        public ActionResult Create()
        {
            IEnumerable<Branch> branch = new Branch[] { new Branch(1, "a", "a", "a", "a") };
            IEnumerable<ServiceOffer> service = new ServiceOffer[] { new ServiceOffer(1, "a", "a", true) };
            SelectList branchList = new SelectList(branch, "Id", "Name");
            SelectList serviceList = new SelectList(service, "Id", "Title");
            ViewBag.Branch = branchList;
            ViewBag.Service = serviceList;
            return View();
        }

        // POST: Admin/Vacancy/Create
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
