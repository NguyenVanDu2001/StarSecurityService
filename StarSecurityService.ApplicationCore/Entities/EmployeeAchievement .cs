using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class EmployeeAchievement : BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId ")]
        public virtual Employyee Employyees { get; set; }
        public int AchievementId { get; set; }
        [ForeignKey("AchievementId ")]
        public virtual Achievement Achievements { get; set; }
    }
}
