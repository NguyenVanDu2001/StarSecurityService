using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Areas.Admin.Model.Histories
{
    public class HistoryCreateOrYpdate
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime TimeLine { get; set; }
        [Required]
        public string Description { get; set; }
        public string FIleName { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}