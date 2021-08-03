using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Areas.Admin.Model.Achievements
{
    public class AchievementModel
    {
        public IEnumerable<Achievement> ListAchievement { get; set; }
        public Achievement entity { get; set; }
    }
}