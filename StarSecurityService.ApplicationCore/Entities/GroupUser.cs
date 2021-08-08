using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class GroupUser : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Employyee> Employyees { get; set; }
        public virtual ICollection<GroupPermesstion> GroupPermesstions { get; set; }
    }
}
