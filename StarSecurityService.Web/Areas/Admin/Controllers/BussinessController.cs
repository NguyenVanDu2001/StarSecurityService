using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class BussinessController : Controller
    {
        // GET: Admin/Bussiness
        private readonly IAsyncRepository<Bussiness> _bussinessReponsitory;
        private readonly IAsyncRepository<Permission> _permisstionReponsitory;
        public BussinessController()
        {
            _bussinessReponsitory = new EfRepository<Bussiness>(new StarServiceDbContext());
            _permisstionReponsitory = new EfRepository<Permission>(new StarServiceDbContext());
        }

        // GET: Bussiness
        public async Task<ActionResult> Index()
        {
            return View(await _bussinessReponsitory.ListAllAsync());
        }
        public async Task<ActionResult> Update()
        {
            var controller = GetControllerHelper.GetController("StarSecurityService.Web.Controllers");
            // insert controller
            foreach (var ctrl in controller)
            {
                Bussiness b = new Bussiness
                {
                    Id = ctrl.Name,
                    Name = ctrl.Name,
                    Status = true
                };
                if (!(await _bussinessReponsitory.GetAll()).Any(x => x.Id.Equals(b.Id)))
                {
                    await _bussinessReponsitory.AddAsync(b);
                }
                // Get Permisssons thuộc Bussiness current
                var actions = GetControllerHelper.GetActions(ctrl);
                foreach (var act in actions)
                {
                    Permission p = new Permission
                    {
                        Id = ctrl.Name + "-" + act, // CategorController-Index
                        Name = ctrl.Name,
                        BusinessId = ctrl.Name,
                        Status = false
                    };
                    if (!(await _permisstionReponsitory.GetAll()).Any(x => x.Id.Equals(p.Id)))
                    {
                        await _permisstionReponsitory.AddAsync(p);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}