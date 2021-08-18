using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Areas.Admin.Model.Achievements
{
    public class AchievementCreateOrUpdateViewModel
    {
        public string  name { get; set; }
        public int  Id { get; set; }
        public HttpPostedFileBase Url { get; set; }
    }
}