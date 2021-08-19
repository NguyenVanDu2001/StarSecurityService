using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Areas.Admin.Model.Histories;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class HistoriesController : Controller
    {
        private StarServiceDbContext db = new StarServiceDbContext();

        // GET: Admin/Histories
        public ActionResult Index()
        {
            return View(db.Histories.ToList());
        }

        // GET: Admin/Histories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.Histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // GET: Admin/Histories/Create
        public ActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                var history = db.Histories.Find(id.Value);
                if (history != null)
                {
                    return View(history);

                }
            }
            return View(new History());
        }

        // POST: Admin/Histories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistoryCreateOrYpdate historyInput)
        {
            if (ModelState.IsValid)
            {
                string _FileName = "";
                if (historyInput.Image != null)
                {
                    _FileName = Path.GetFileName(historyInput.Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                    historyInput.Image.SaveAs(_path);
                }
                else 
                {
                    _FileName = historyInput.FIleName;
                }

                var history = new History();
                history.CreateAt = DateTime.Now;
                history.Description = historyInput.Description;
                history.Id = historyInput.Id;
                history.Image = _FileName;
                history.TimeLine = historyInput.TimeLine;
                history.Title = historyInput.Title;
                if (historyInput.Id == 0)
                {
                     db.Histories.Add(history);
                }
                else
                {
                    db.Entry(history).State = EntityState.Modified;
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historyInput);
        }

        // GET: Admin/Histories/Edit/5
       
        // GET: Admin/Histories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History history = db.Histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // POST: Admin/Histories/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            History history = db.Histories.Find(id);
            db.Histories.Remove(history);
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
