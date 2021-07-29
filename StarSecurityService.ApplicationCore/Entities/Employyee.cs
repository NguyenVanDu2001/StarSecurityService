using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Employyee : BaseEntity<int>
    {
        public string Code{ get; set; }
        public string Name { get; set; }
        public string Adress{ get; set; }
        public int ContactNumber{ get; set; }
        public int? Role { get; set; }
        public bool Grade { get; set; }
        public int Client { get; set; }
        public int? Achievements { get; set; }
        public DateTime BirthDay { get; set; }
      
    }
}
