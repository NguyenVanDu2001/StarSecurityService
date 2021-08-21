using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class GroupUserController : Controller
    {
        private readonly IAsyncRepository<Bussiness> _bussinessReponsitory;
        private readonly IAsyncRepository<GroupUser> _groupUserReponsitory;
        private readonly IAsyncRepository<Permission> _permisstionReponsitory;
        private readonly IAsyncRepository<GroupPermesstion> _groupPermissionReponsitory;
        // GET: Admin/GroupUser
        public GroupUserController()
        {
            _bussinessReponsitory = new EfRepository<Bussiness>(new StarServiceDbContext());
            _groupUserReponsitory = new EfRepository<GroupUser>(new StarServiceDbContext());
            _permisstionReponsitory = new EfRepository<Permission>(new StarServiceDbContext());
            _groupPermissionReponsitory = new EfRepository<GroupPermesstion>(new StarServiceDbContext());

        }
        public async Task<ActionResult> Index()
        {
            var data = await _groupUserReponsitory.ListAllAsync();
            return View(data);
        }
        public async Task<ActionResult> Create(int? id)
        {
            var groupUser = new GroupUser();
            if (id.HasValue)
            {
                groupUser =  _groupUserReponsitory.GetById(id.Value);
            }
            return View(groupUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(GroupUser groupUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (groupUser.Id > 0)
                        await _groupUserReponsitory.UpdateAsync(groupUser);
                    else
                        await _groupUserReponsitory.AddAsync(groupUser);

                    return RedirectToAction("Index");
                }
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<ActionResult> GrantPermisstion(int groupId)
        {
            // llay các nghiệp vụ
            var _bussiness = (await  _bussinessReponsitory.ListAllAsync()).AsEnumerable();
            foreach (var item in _bussiness)
            {
                // lấy các quyền của nghiệp vụ
                var _permissions =( await _permisstionReponsitory.ListAsync(x => x.BusinessId.Equals(item.Id))).ToList();
                    // kiểm tra các nghiệp vụ nào được gán r
                foreach (var per in _permissions)
                {
                    if (await _groupPermissionReponsitory.CountAsync(x => x.GroupId == groupId && x.PermisstionId.Equals(per.Id)) > 0)
                    {
                        per.Status = true; // gán r 
                    }
                    else
                    {
                        per.Status = false;// chưa gán
                    }
                }
                item.Permissions =  _permissions;
            }
            ViewBag.groupId = groupId;
            return View(_bussiness);
        }
        public async Task<ActionResult> GrantPer(int grouId, string id_permis)
        {
            string msg = string.Empty;
            var groupPer =( await _groupPermissionReponsitory.ListAsync(x => x.GroupId.Equals(grouId) && x.PermisstionId.Equals(id_permis))).SingleOrDefault();
            if (groupPer != null) 
            {
               await _groupPermissionReponsitory.DeleteAsync(groupPer);
                msg = $"Delete permission success";
            }
            else // if not permission then add permission
            {
                await _groupPermissionReponsitory.AddAsync(new GroupPermesstion { GroupId = grouId, PermisstionId = id_permis });
                msg = $"Grant permisson success";
            }
            return Json(new { Message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}