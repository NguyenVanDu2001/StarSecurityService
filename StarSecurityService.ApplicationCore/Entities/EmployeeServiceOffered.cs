using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class EmployeeServiceOffered : BaseEntity<int>
    {
        public int EmployeeId{ get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employyee Employyees { get; set; }
        public int ServiceOfferId { get; set; }
        [ForeignKey("ServiceOfferId")]
        public virtual ServiceOffer ServiceOffers  { get; set; }
    }
}
