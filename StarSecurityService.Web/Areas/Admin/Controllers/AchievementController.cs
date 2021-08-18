using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Areas.Admin.Model.Achievements;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class AchievementController : Controller
    {
         private readonly IAsyncRepository<Achievement> _achievementReponsitory;
        public AchievementController()
        {
            _achievementReponsitory = new EfRepository<Achievement>(new StarServiceDbContext());
        }
        // GET: Admin/Achievement
        public async Task<ActionResult> Index(int? Id)
        {

            var data = await _achievementReponsitory.ListAllAsync();
            string name = string.Empty;
            Achievement entity = null;
            if (Id.HasValue)
            {
                 entity = await _achievementReponsitory.FirstOrDefaultAsync(x => x.Id == Id);
            }
            var model = new AchievementModel
            {
                ListAchievement = data,
                entity = entity != null ? entity  : new Achievement()
            };
            return View(model);
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public async Task<ActionResult> SubmitForm(AchievementCreateOrUpdateViewModel input)
        {
            if (!ModelState.IsValid)
                return View();

            string _FileName = string.Empty;
            if (input.Url != null)
            {

                 _FileName = Path.GetFileName(input.Url.FileName);
                string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                input.Url.SaveAs(_path);

            }
            else if (input.Id > 0)
            {
                var achi = (await _achievementReponsitory.GetByIdAsync(input.Id));
                _FileName = achi != null ? achi?.Url : string.Empty;
            }

            var achivement = new Achievement    
            {
                Url = _FileName,
                Id = input.Id,
                name = input.name
            };
            if (achivement.Id > 0)
                await _achievementReponsitory.UpdateAsync(achivement);
            else
                await _achievementReponsitory.AddAsync(achivement);

            return RedirectToAction("index");
        }
    }
}