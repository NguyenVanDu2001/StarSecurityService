using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class ServiceOfferController : Controller
    {
        // GET: Admin/ServiceOffer
        public ActionResult Index()
        {
            IEnumerable<ServiceOffer> items = new ServiceOffer[] { new ServiceOffer(1, "a", "a", true) };
            return View(items);
        }

        // GET: Admin/ServiceOffer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ServiceOffer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServiceOffer/Create
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

        // GET: Admin/ServiceOffer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ServiceOffer/Edit/5
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

        // GET: Admin/ServiceOffer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ServiceOffer/Delete/5
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
