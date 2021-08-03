using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Admin/Candidate
        public ActionResult Index()
        {
            IEnumerable<Candidate> items = new Candidate[] { new Candidate(1, "a", "a", 1, "a", "a", new DateTime(), true)  };
            return View(items);
        }

        // GET: Admin/Candidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Candidate/Create
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

        // GET: Admin/Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Candidate/Edit/5
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

        // GET: Admin/Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Candidate/Delete/5
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
