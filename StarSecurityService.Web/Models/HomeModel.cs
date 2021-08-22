using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Models
{
    public class HomeModel
    {
    }
    public class HomeAboutUs
    {
        public IEnumerable<History> HistoryModel { get; set; }
        public IEnumerable<ShareHolder> ShareHolderModel { get; set; }
    }
}