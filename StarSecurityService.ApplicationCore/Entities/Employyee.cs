using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Employyee
    {
        public int Id{ get; set; }
        public int BranchId { get; set; }
        public string Address{ get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool sex { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDay { get; set; }

        public Employyee(int id, int branchId, string address, string image, string password, string email, string phone, bool sex, bool status, DateTime birthDay)
        {
            Id = id;
            BranchId = branchId;
            Address = address;
            Image = image;
            Password = password;
            Email = email;
            Phone = phone;
            this.sex = sex;
            Status = status;
            BirthDay = birthDay;
        }
    }
}
