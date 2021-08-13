using StarSecurityService.Application.Clients;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientAppService _clientAppServices;
        public ClientController()
        {
            _clientAppServices = new ClientAppServices();
        }
        public async Task<ActionResult> Index()
        {
            var items = await _clientAppServices.GetAll();
            return View(items);
        }

        // GET: Admin/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                // TODO: Add insert logic here
                _clientAppServices.AddAsync(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Client/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var db = await _clientAppServices.FirstOrDefaultAsync(id);
            return View(db);
        }

        // POST: Admin/Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                // TODO: Add update logic here
                _clientAppServices.UpdateAsync(client);
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
            _clientAppServices.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
