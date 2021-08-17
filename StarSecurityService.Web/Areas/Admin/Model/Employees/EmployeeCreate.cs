using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Areas.Admin.Model.Employees
{
    public class EmployeeCreate  :Employyee
    {
        public int Id{ get; set; }
        public int? BranchId { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Salary { get; set; }
        public string UserName { get; set; }
        public decimal Bonus { get; set; }
        public int? GroupId { get; set; }
        public virtual ICollection<ClientEmployees> ClientEmployees { get; set; }
        public List<ComboboxCommonDto> ListClient { get; set; }
        public List<ComboboxCommonDto> ListServiceOffer { get; set; }
        public List<int> ListValueAchievemet { get; set; }
        public List<int> ListValueServiceOffer { get; set; }
    }
}