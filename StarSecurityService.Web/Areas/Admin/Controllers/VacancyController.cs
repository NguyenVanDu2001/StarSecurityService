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
            IEnumerable<Vacancy> items = new Vacancy[] { new Vacancy(1, "a", 1, 1, new DateTime(), new DateTime(), true) };
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
