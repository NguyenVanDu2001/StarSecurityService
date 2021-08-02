using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class User : BaseEntity<int>
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public int GroupId { get; set; }
        public bool Status { get; set; }
        [ForeignKey("GroupId")]
        public GroupUser GroupUsers { get; set; }
    }
}
