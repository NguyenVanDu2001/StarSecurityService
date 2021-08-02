using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Branch(int id, string name, string phone, string email, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
