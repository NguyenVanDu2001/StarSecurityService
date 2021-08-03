using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    [Table ("GroupPermesstion")]
    public class GroupPermesstion
    {
        [Key, Column(Order = 0)]
        public int GroupId { get; set; }
        [Key, Column(Order = 1)]
        public string PermisstionId { get; set; }
        [ForeignKey("GroupId")]
        public virtual GroupUser GroupUsers { get; set; }
        [ForeignKey("PermisstionId")]
        public virtual Permission Permissions { get; set; }
    }
}
