using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.DTO;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class ServiceOfferController : Controller
    {
        private readonly IServiceOfferService _serviceOfferService;
        public ServiceOfferController()
        {
            _serviceOfferService = new ServiceOfferService();
        }
        // GET: Admin/ServiceOffer
        public async Task<ActionResult> Index()
        {
            var items = await _serviceOfferService.GetAll();
            return View(items);
        }

        // GET: Admin/ServiceOffer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServiceOffer/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ServiceOffer service)
        {
            try
            {
                var name = "";
                foreach (HttpPostedFileBase item in service.Url)
                {
                    string _FileName = Path.GetFileName(item.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                    item.SaveAs(_path);
                    name += item.FileName+ " ";
                }
                name = name.Trim();
                _serviceOfferService.AddAsync(service, name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ServiceOffer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var db = await _serviceOfferService.FirstOrDefaultAsync(id);
            string[] image = db.Url.Split(' ');
            List<string> path = new List<string>();
            foreach (string img in image) {
                path.Add(img);
            }
            ViewBag.Image = path;
            return View(db);
        }

        // POST: Admin/ServiceOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServiceOfferViewModel service)
        {
            try
            {
                var fileName = "";
                if(service.Url[0] != null)
                {
                    foreach (HttpPostedFileBase item in service.Url)
                    {
                        string _FileName = Path.GetFileName(item.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                        item.SaveAs(_path);
                        fileName += item.FileName + " ";
                    }
                } else
                {
                    var db = _serviceOfferService.FirstOrDefaultAsync(id).Result;
                    fileName = db.Url;
                }
                fileName = fileName.Trim();
                _serviceOfferService.UpdateAsync(service, fileName, id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/ServiceOffer/Delete/5
        public ActionResult Delete(int id)
        {
            _serviceOfferService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
