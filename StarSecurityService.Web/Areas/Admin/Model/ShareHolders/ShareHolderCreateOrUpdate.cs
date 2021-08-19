using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Areas.Admin.Model.ShareHolders
{
    public class ShareHolderCreateOrUpdate
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageName { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public DateTime JoinCreateAt { get; set; }
    }
}