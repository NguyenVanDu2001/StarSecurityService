using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }

        public Vacancy(int id, string description, int employeeId, int branchId, DateTime endDate, DateTime startDate, bool status)
        {
            Id = id;
            Description = description;
            EmployeeId = employeeId;
            BranchId = branchId;
            EndDate = endDate;
            StartDate = startDate;
            Status = status;
        }
    }
}
