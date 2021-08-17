using Newtonsoft.Json;
using StarSecurityService.Application.Achievements;
using StarSecurityService.Application.Branchs;
using StarSecurityService.Application.Clients;
using StarSecurityService.Application.CLientServices;
using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.Application.EmployeeAchievements;
using StarSecurityService.Application.Employees;
using StarSecurityService.Application.Employees.Dto;
using StarSecurityService.Application.EmployeeSerivceOffers;
using StarSecurityService.Application.ServiceOffers;
using StarSecurityService.ApplicationCore.Commons.Enums;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.Web.Areas.Admin.Model.Employees;
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
    [CustomAuthorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IClientAppService _clientAppServices;
        private readonly IServiceOfferService _serviceOfferAppServices;
        private readonly IBrachAppService _brachAppService;
        private readonly IAchievementAppService _achievementAppService;
        private readonly IEmployeeServiceOfferAppSerivce _employeeServiceOfferAppSerivce;
        private readonly IEmployeeAchievementAppService _employeeAchievementAppService;
        private readonly IClientEmployeeAppService _clientEmployeeAppService;
        public EmployeeController()
        {
            _employeeAppService = new EmployeeAppServices();
            _clientAppServices = new ClientAppServices();
            _serviceOfferAppServices = new ServiceOfferService();
            _brachAppService = new BranchAppService();
            _achievementAppService = new AchievementAppService();
            _employeeServiceOfferAppSerivce = new EmployeeServiceOfferAppService();
            _employeeAchievementAppService = new EmployeeAchievementAppService();
            _clientEmployeeAppService = new ClientEmployeeAppService();
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
        public async Task<ActionResult> Create(int? id)
        {
            ViewBag.ListClient = await _clientAppServices.GetComboboxClient();
            ViewBag.ListServiceOffer = await _serviceOfferAppServices.GetComboboxServiceOffer();
            if (id.HasValue)
            {
                var em = await _employeeAppService.GetById(id.Value);

                 var listId = new List<int>();
                foreach (var item in em.EmployeeServiceOffered)
                {
                    listId.Add(item.ServiceOfferId);
                }
                ViewBag.ListIdServiceOffer = JsonConvert.SerializeObject(listId);
                var listAchiId = new List<int>();
                foreach (var item in em.EmployeeAchievements)
                {
                    listAchiId.Add(item.AchievementId);
                }
                ViewBag.ListIdAchi = JsonConvert.SerializeObject(listAchiId);


                return View(em);
            }
            return View(new Employyee());
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

            try
            {
                var objectEmployee = new JavaScriptSerializer().Deserialize<EmployeeCreateOrUpdateInputDto>(formCollection["employyee"]);
                var listAchivement = new JavaScriptSerializer().Deserialize<List<int>>(formCollection["listAchievement"]);
                var listServiceOffer = new JavaScriptSerializer().Deserialize<List<int>>(formCollection["listServiceOffer"]);
                var listserviceEmployee = new JavaScriptSerializer().Deserialize<List<ClientEmployeeCreateDto>>(formCollection["serviceEmployee"]);
                HttpFileCollectionBase files = Request.Files;

                string fname = string.Empty;
                if (files.Count > 0)
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
                    // Edit
                    if (objectEmployee.Id > 0)
                    {
                        var employee = await _employeeAppService.GetById(objectEmployee.Id);
                        if (string.IsNullOrEmpty(fname))
                        {
                            fname = employee.Image;
                        }
                        await _employeeServiceOfferAppSerivce.DeleteByEmployeeId(objectEmployee.Id);
                        await _employeeAchievementAppService.DeleteByEmployeeId(objectEmployee.Id);
                        await _clientEmployeeAppService.DeleteByEmployeeId(objectEmployee.Id);

                    }
                    var emp = new Employyee
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
                    };

                    int idNhanVien = objectEmployee.Id;
                    if (idNhanVien == 0)
                    {
                        idNhanVien = await _employeeAppService.InsertAndGetIdAsync(emp);
                    }
                    else
                    {
                        await _employeeAppService.UpdateAndGetIdAsync(emp);
                    }
                    if (listAchivement.Count > 0)
                    {
                        // Convert and add service offer 
                        var listServiceOffers = new List<EmployeeServiceOffered>();
                        foreach (var item in listServiceOffer)
                        {
                            listServiceOffers.Add(new EmployeeServiceOffered
                            {
                                EmployeeId = idNhanVien,
                                ServiceOfferId = item,
                            });
                        }
                        bool isSave = await _employeeServiceOfferAppSerivce.InsertMuntiple(listServiceOffers);
                        if (!isSave)
                        {
                            return null;
                        }
                        // convert and insert achievement
                        var listEmployeeAchievement = new List<EmployeeAchievement>();
                        foreach (var item in listAchivement)
                        {
                            listEmployeeAchievement.Add(new EmployeeAchievement
                            {
                                EmployeeId = idNhanVien,
                                AchievementId = item,
                            });
                        }
                        bool isSaveAchiViement = await _employeeAchievementAppService.InsertMuntiple(listEmployeeAchievement);
                        if (!isSaveAchiViement)
                        {
                            return null;
                        }

                        // convert and insert client
                        var listclient = new List<ClientEmployees>();
                        foreach (var item in listserviceEmployee)
                        {
                            listclient.Add(new ClientEmployees
                            {
                                ClientId = item.ClientId,
                                EmployeeId = idNhanVien,
                                ServiceOfferId = item.ServiceOfferId,
                                ShiftEnd = item.EndShift.Value,
                                ShiftStart = item.StartShift.Value
                            });
                        }
                        await _clientEmployeeAppService.InsertMuntiple(listclient);
                        //

                    }
                }

            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
                
           
            return Json(1);
        }
            
    }
}
