using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Achievement : BaseEntity<int>
    {
        public string name { get; set; }
        public virtual ICollection<EmployeeAchievement> EmployeeAchievements { get; set; }
    }
}
