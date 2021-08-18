using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ShareHolder : BaseEntity<int>
    {
        [Required]
        public string  Name { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public int  Phone { get; set; }
        [Required]
        public string Description{ get; set; }
        [Required]
        public string Image{ get; set; }
        public string Address{ get; set; }
        public int Status{ get; set; }
        public DateTime JoinCreateAt { get; set; }
    }
}
