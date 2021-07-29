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

namespace StarSecurityService.Web.Controllers
{
    public class BussinessController : Controller
    {
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
                // lấy các Permisssons thuộc Bussiness hiện tại
                var actions = GetControllerHelper.GetActions(ctrl);
                foreach (var act in actions)
                {
                    Permission p = new Permission
                    {
                        Id = ctrl.Name + "-" + act, // CategorController-Index
                        Name = "Updating....",
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