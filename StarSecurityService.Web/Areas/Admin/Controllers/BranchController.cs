using StarSecurityService.Application.Branchs;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBrachAppService _brachAppService;
        public BranchController()
        {
            _brachAppService = new BranchAppService();
    }
        // GET: Admin/Branch
        public async Task<ActionResult> Index()
        {
            return View(await _brachAppService.GetAllBranchs());
        }

        // GET: Admin/Branch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Branch/Create
        public async Task<ActionResult> Create(int? id)
        {
            if (id.HasValue)
            {
                var model = await _brachAppService.GetByIdBranch(id.Value);
                return View(model);
            }
            return View(new Branch());
        }

        // POST: Admin/Branch/Create
        [HttpPost]
        public async Task<ActionResult> Create(Branch branch)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                  await  _brachAppService.AddBranch(branch);
                    return RedirectToAction("Index");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Branch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Branch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
