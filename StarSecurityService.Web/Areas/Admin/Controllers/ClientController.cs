using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        // GET: Admin/Client
        public ActionResult Index()
        {
            IEnumerable<Client> items = new Client[] { new Client(1, "a", "a", "a", "a") };
            return View(items);
        }

        // GET: Admin/Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Client/Create
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

        // GET: Admin/Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Client/Edit/5
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

        // GET: Admin/Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Client/Delete/5
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
