using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Employees.Dto
{
   public class EmployeeCreateOrUpdateInputDto
    {
        public int Id { get; set; }
        public string Address{ get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }
        public bool Status { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal Salary { get; set; }
        public string UserName { get; set; }
        public decimal Bonus { get; set; }
        public int? BranchId { get; set; }
        public int? GroupId { get; set; }
    }
    public class ClientEmployeeCreateDto
    {
        public int ClientId{ get; set; }
        public int ServiceOfferId { get; set; }
        public DateTime? StartShift { get; set; }
        public DateTime? EndShift { get; set; }
    }
    
}
