using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ServiceOffer
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Details { get; set; }
        public bool Status { get; set; }

        public ServiceOffer(int id, string title, string details, bool status)
        {
            Id = id;
            Title = title;
            Details = details;
            Status = status;
        }
    }
}
