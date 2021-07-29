using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAsyncRepository<Employyee> _employeeReponsitory;
        public EmployeeController(IAsyncRepository<Employyee> employeeReponsitory)
        {
            _employeeReponsitory = employeeReponsitory;
        }
        public EmployeeController()
        {
            _employeeReponsitory = new EfRepository<Employyee>(new StarServiceDbContext());
        }
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var getall = await _employeeReponsitory.ListAllAsync();
            return View(getall);
        }
        [HttpGet]
        public async Task<ActionResult> Create(int? Id)
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(Employyee employyee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
               await _employeeReponsitory.AddAsync(employyee);
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}