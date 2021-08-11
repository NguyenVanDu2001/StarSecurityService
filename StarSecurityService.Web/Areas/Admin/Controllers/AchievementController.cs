using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using StarSecurityService.Web.Areas.Admin.Model.Achievements;
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
                entity = entity != null ? entity  : null
            };
            return View(model);
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public async Task<ActionResult> SubmitForm(Achievement achievement)
        {
            if (!ModelState.IsValid)
                return View();

            if (achievement.Id > 0)
                await _achievementReponsitory.UpdateAsync(achievement);
            else
                await _achievementReponsitory.AddAsync(achievement);

            return RedirectToAction("index");
        }
    }
}