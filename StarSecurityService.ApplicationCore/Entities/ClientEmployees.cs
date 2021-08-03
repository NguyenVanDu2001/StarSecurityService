using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ClientEmployees : BaseEntity<int>
    {
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Clients { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employyee Employyees { get; set; }
        public int  EmployeeId{ get; set; }
        [ForeignKey("ServiceOfferId")]
        public virtual ServiceOffer ServiceOffer { get; set; }
        public int  ServiceOfferId{ get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

    }
}
