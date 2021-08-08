using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Vacancy : BaseEntity<int>
    {
        public string Requirement { get; set; }
        public string Title { get; set; }
        public int UpdateBy { get; set; }
        [ForeignKey("UpdateBy")]
        public virtual Employyee Employyees { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branchs { get; set; }
        public int ServiceOfferId { get; set; }
        [ForeignKey("ServiceOfferId")]
        public virtual ServiceOffer ServiceOffer { get; set; }
        public DateTime UpdateAt { get; set; }
        public float Salary { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

        public Vacancy()
        {
        }

        public Vacancy(string requirement, string description, int updateBy, Employyee employyees, int branchId, Branch branchs, int serviceOfferId,
            ServiceOffer serviceOffer, DateTime updateAt, float salary, bool status, ICollection<Candidate> permissions)
        {
            Requirement = requirement;
            Title = description;
            UpdateBy = updateBy;
            Employyees = employyees;
            BranchId = branchId;
            Branchs = branchs;
            ServiceOfferId = serviceOfferId;
            ServiceOffer = serviceOffer;
            UpdateAt = updateAt;
            Salary = salary;
            Status = status;
            Candidates = permissions;
        }
    }
}
