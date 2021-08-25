using StarSecurityService.Application.Clients;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.Web.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
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
        public ActionResult Create(Client client, HttpPostedFileBase Image)
        {
            try
            {

                if (Image != null)
                {
                    client.Image = Image.FileName;
                    string _FileName = Path.GetFileName(Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                    Image.SaveAs(_path);
                }

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
        public ActionResult Edit(int id, Client client, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add update logic here
                if (Image != null)
                {
                    client.Image = Image.FileName;
                    string _FileName = Path.GetFileName(Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                    Image.SaveAs(_path);
                }

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
        public async Task<JsonResult> GetAllEmployeeByClientId(int Id)
        {
            var client = await _clientAppServices.FirstOrDefaultAsync(Id);
            var res = new Response<List<EmployeeRes>>();

            var data = new List<EmployeeRes>();
            if (client != null)
            {
                if (client.ClientEmployees?.Any() == true)
                {
                    foreach (var item in client.ClientEmployees)
                    {
                        data.Add(new EmployeeRes
                        {
                            EmployeeName = item?.Employyees?.UserName,
                            Status = item?.Employyees?.Status,
                            ClientName = client.Name,
                        });
                    }
                }
            }
            res.Data = data;
            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
    public class EmployeeRes
    {
        public string  EmployeeName { get; set; }
        public string  ClientName { get; set; }
        public string StatusName { get {
                if (this.Status.HasValue && this.Status.Value)
                {
                    return "Active";
                }
                else
                {
                    return "No Active";
                }
            } }
        public string  ShifDate { get; set; }
        public string  EndDate{ get; set; }
        public bool? Status { get; set; }


    }
}
