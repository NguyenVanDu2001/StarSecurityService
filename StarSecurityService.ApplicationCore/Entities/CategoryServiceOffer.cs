using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class CategoryServiceOffer : BaseEntity<int>
    {
        public string Name  { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<ServiceOffer> ServiceOffers { get; set; }

    }
}
