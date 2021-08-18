using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class History : BaseEntity<int>
    {
        [Required]
        public string Title { get; set; }
        public DateTime TimeLine { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
