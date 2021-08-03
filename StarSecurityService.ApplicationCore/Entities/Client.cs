using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ClientEmployees> ClientEmployees { get; set; }

        public Client(int id, string name, string phone, string image, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Image = image;
            Address = address;
        }
        public Client()
        {

        }
    }
}
