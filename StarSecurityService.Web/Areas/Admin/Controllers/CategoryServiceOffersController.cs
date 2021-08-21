using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.EntityFramework.Data;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class CategoryServiceOffersController : Controller
    {
        private StarServiceDbContext db = new StarServiceDbContext();

        // GET: Admin/CategoryServiceOffers
        public ActionResult Index()
        {
            return View(db.CategoryServiceOffers.ToList());
        }

        // GET: Admin/CategoryServiceOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryServiceOffer categoryServiceOffer = db.CategoryServiceOffers.Find(id);
            if (categoryServiceOffer == null)
            {
                return HttpNotFound();
            }
            return View(categoryServiceOffer);
        }

        // GET: Admin/CategoryServiceOffers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryServiceOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status")] CategoryServiceOffer categoryServiceOffer)
        {
            if (ModelState.IsValid)
            {
                db.CategoryServiceOffers.Add(categoryServiceOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryServiceOffer);
        }

        // GET: Admin/CategoryServiceOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryServiceOffer categoryServiceOffer = db.CategoryServiceOffers.Find(id);
            if (categoryServiceOffer == null)
            {
                return HttpNotFound();
            }
            return View(categoryServiceOffer);
        }

        // POST: Admin/CategoryServiceOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status")] CategoryServiceOffer categoryServiceOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryServiceOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryServiceOffer);
        }

        // GET: Admin/CategoryServiceOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryServiceOffer categoryServiceOffer = db.CategoryServiceOffers.Find(id);
            if (categoryServiceOffer == null)
            {
                return HttpNotFound();
            }
            return View(categoryServiceOffer);
        }

        // POST: Admin/CategoryServiceOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryServiceOffer categoryServiceOffer = db.CategoryServiceOffers.Find(id);
            db.CategoryServiceOffers.Remove(categoryServiceOffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
