using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Image { get; set; }
        public String Address { get; set; }

        public Client(int id, string name, string phone, string image, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Image = image;
            Address = address;
        }
    }
}
