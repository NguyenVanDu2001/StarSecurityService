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
using StarSecurityService.Web.Areas.Admin.Model.ShareHolders;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ShareHoldersController : Controller
    {
        private StarServiceDbContext db = new StarServiceDbContext();

        // GET: Admin/ShareHolders
        public ActionResult Index()
        {
            return View(db.ShareHolders.ToList());
        }

        // GET: Admin/ShareHolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareHolder shareHolder = db.ShareHolders.Find(id);
            if (shareHolder == null)
            {
                return HttpNotFound();
            }
            return View(shareHolder);
        }

        // GET: Admin/ShareHolders/Create
        public ActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                var shareHolder = db.ShareHolders.Find(id.Value);
                if (shareHolder != null)
                {
                    return View(shareHolder);

                }
            }
            return View(new ShareHolder());
        }

        // POST: Admin/ShareHolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShareHolderCreateOrUpdate shareHolder)
        {
            try
            {
               
                    string _FileName = "";
                    if (shareHolder.Image != null)
                    {
                        _FileName = Path.GetFileName(shareHolder.Image.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                        shareHolder.Image.SaveAs(_path);
                    }
                    else
                    {
                        _FileName = shareHolder.ImageName;
                    }

                    var shareHolderEntity = new ShareHolder
                    {
                        Id = shareHolder.Id,
                        Image = _FileName,
                        Address = shareHolder.Address,
                        Description = shareHolder.Description,
                        Email = shareHolder.Email,
                        JoinCreateAt = shareHolder.JoinCreateAt,
                        Name = shareHolder.Name,
                        Phone = shareHolder.Phone,
                        Status = shareHolder.Status,
                    };
                    if (shareHolder.Id > 0)
                    {
                        ShareHolder shareHolderDb = db.ShareHolders.Find(shareHolder.Id);
                        shareHolderDb.Image = _FileName;
                        shareHolderDb.Address = shareHolder.Address;
                        shareHolderDb.Description = shareHolder.Description;
                        shareHolderDb.Email = shareHolder.Email;
                        shareHolderDb.JoinCreateAt = shareHolder.JoinCreateAt;
                        shareHolderDb.Name = shareHolder.Name;
                        shareHolderDb.Phone = shareHolder.Phone;
                        shareHolderDb.Status = shareHolder.Status;

                        db.Entry(shareHolderDb).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {

                        db.ShareHolders.Add(shareHolderEntity);
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                

            }
            catch (Exception ex)
            {
                return View(shareHolder);

            }
        }

        // GET: Admin/ShareHolders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareHolder shareHolder = db.ShareHolders.Find(id);
            if (shareHolder == null)
            {
                return HttpNotFound();
            }
            return View(shareHolder);
        }

        // POST: Admin/ShareHolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,Description,Image,Address,Status,JoinCreateAt")] ShareHolder shareHolder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shareHolder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shareHolder);
        }

        // GET: Admin/ShareHolders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareHolder shareHolder = db.ShareHolders.Find(id);
            if (shareHolder == null)
            {
                return HttpNotFound();
            }
            return View(shareHolder);
        }

        // POST: Admin/ShareHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShareHolder shareHolder = db.ShareHolders.Find(id);
            db.ShareHolders.Remove(shareHolder);
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
