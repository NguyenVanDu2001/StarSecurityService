using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Permission : BaseEntity<string>
    {
        public string Name { get; set; }
        public string BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual Bussiness Bussinesses { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<GroupPermesstion> GroupPermesstions { get; set; }

    }
}
