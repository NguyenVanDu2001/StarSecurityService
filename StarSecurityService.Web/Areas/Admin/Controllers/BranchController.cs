using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        // GET: Admin/Branch
        public ActionResult Index()
        {
            IEnumerable<Branch> items = new Branch[] { new Branch(1, "a", "a", "a", "a") };
            return View(items);
        }

        // GET: Admin/Branch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Branch/Create
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

        // GET: Admin/Branch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Branch/Edit/5
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

        // GET: Admin/Branch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Branch/Delete/5
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
