using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Vacancy : BaseEntity<int>
    {
        public string Requirement{ get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employyee Employyees{ get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branchs { get; set; }
        public int ServiceOfferId { get; set; }
        [ForeignKey("ServiceOfferId")]
        public virtual ServiceOffer ServiceOffer { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Candidate> Permissions { get; set; }

        public Vacancy(string requirement, string description, int employeeId, Employyee employyees, int branchId, Branch branchs, int serviceOfferId, ServiceOffer serviceOffer, DateTime endDate, DateTime startDate, bool status, ICollection<Candidate> permissions)
        {
            Requirement = requirement;
            Description = description;
            EmployeeId = employeeId;
            Employyees = employyees;
            BranchId = branchId;
            Branchs = branchs;
            ServiceOfferId = serviceOfferId;
            ServiceOffer = serviceOffer;
            EndDate = endDate;
            StartDate = startDate;
            Status = status;
            Permissions = permissions;
        }
    }
}
