using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Employyee : BaseEntity<int>
    {
        public int? BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branchs { get; set; }
        public string Address{ get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual ICollection<EmployeeAchievement> EmployeeAchievements { get; set; }
        public virtual ICollection<ClientEmployees> ClientEmployees { get; set; }
        public virtual ICollection<EmployeeServiceOffered> EmployeeServiceOffered { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public Employyee(int id, int branchId, string address, string image, string password, string email, string phone, bool sex, bool status, DateTime birthDay)
        {
            Id = id;
            BranchId = branchId;
            Address = address;
            Image = image;
            Password = password;
            Email = email;
            Phone = phone;
            this.Sex = sex;
            Status = status;    
            BirthDay = birthDay;
        }
        public Employyee()
        {

        }
    }
}
