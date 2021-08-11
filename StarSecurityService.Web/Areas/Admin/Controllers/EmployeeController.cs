using StarSecurityService.Application.Achievements;
using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.Application.Employees;
using StarSecurityService.Application.Employees.Dto;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Commons.Enums;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Commons;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IClientAppService _clientAppServices;
        private readonly IServiceOfferService _serviceOfferAppServices;
        private readonly IBrachAppService _brachAppService;
        private readonly IAchievementAppService _achievementAppService;
        public EmployeeController()
        {
            _employeeAppService = new EmployeeAppServices();
            _clientAppServices = new ClientAppServices();
            _serviceOfferAppServices = new ServiceOfferService();
            _brachAppService = new BranchAppService();
            _achievementAppService = new AchievementAppService();
        }
     
        // GET: Admin/Employee
        public async Task<ActionResult> Index()
        {
            var items = await _employeeAppService.GetAllEmployee();
            return View(items);
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create(int? id =0)
        {
            if (id.HasValue)
            {

            }
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Edit/5
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

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
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
        [HttpGet]
        public async Task<JsonResult> LoadComboboxClient()
        {
            var res = new Response<List<ComboboxCommonDto>>()
            {
                Data = await _clientAppServices.GetComboboxClient(),
                Message = "Success"
            };
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> LoadComboboxService()
        {
            var res = new Response<List<ComboboxCommonDto>>();
            try
            {
                res.Data = await _serviceOfferAppServices.GetComboboxServiceOffer();
                res.Message = "Success";
            }
            catch (System.Exception ex)
            {
                res.Message = "An error occurred";
                res.StatusCode = HttpStatusCode.OK;
                res.Status = StatusEnum.BadRequest;
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> LoadComboboxBranch()
        {
            var res = new Response<List<ComboboxCommonDto>>();
            try
            {
                res.Data = await _brachAppService.GetAllForCombobox();
                res.Message = "Success";
            }
            catch (System.Exception ex)
            {
                res.Message = "An error occurred";
                res.StatusCode = HttpStatusCode.OK;
                res.Status = StatusEnum.BadRequest;
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> LoadComboboxAchievemt()
        {
            var res = new Response<List<ComboboxCommonDto>>();
            try
            {
                res.Data = await _achievementAppService.GetAllComboboxAchievemnt();
                res.Message = "Success";
            }
            catch (System.Exception ex)
            {
                res.Message = "An error occurred";
                res.StatusCode = HttpStatusCode.OK;
                res.Status = StatusEnum.BadRequest;
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> SubmitForm(FormCollection formCollection, HttpPostedFileBase inputFile)
        {
            
             var objectEmployee = new JavaScriptSerializer().Deserialize<EmployeeCreateOrUpdateInputDto>(formCollection["employyee"]);

             HttpFileCollectionBase files = Request.Files;

            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
            //string filename = Path.GetFileName(Request.Files[i].FileName);  
            string fname = string.Empty;
            if (files != null)
            {

                HttpPostedFileBase file = files[0];
               

                // Checking for Internet Explorer  
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                }

                // Get the complete folder path and store the file inside it.  
                fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                file.SaveAs(fname);
            }
            if (objectEmployee != null)
            {
                int idNhanVien = await _employeeAppService.InsertAndGetIdAsync(new Employyee
                {
                    Id = objectEmployee.Id,
                    Address = objectEmployee.Address,
                    BirthDay = objectEmployee.BirthDay,
                    GroupId = 3,
                    Image = fname,
                    BranchId = objectEmployee.BranchId,
                    Password = objectEmployee.Password,
                    Bonus = objectEmployee.Bonus,
                    Email = objectEmployee.Email,
                    Phone = objectEmployee.Phone,
                    Salary = objectEmployee.Salary,
                    Sex = objectEmployee.Sex,
                    Status = objectEmployee.Status,
                    UserName = objectEmployee.UserName,
                });

            }

                
           
            return Json(1);
        }
            
    }
}
