using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
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
        public ActionResult Create(ServiceOffer service)
        {
            try
            {
                // TODO: Add insert logic here
                _serviceOfferService.AddAsync(service);
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
            return View(db);
        }

        // POST: Admin/ServiceOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServiceOffer service)
        {
            try
            {
                // TODO: Add update logic here
                _serviceOfferService.UpdateAsync(service);
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
            _serviceOfferService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
