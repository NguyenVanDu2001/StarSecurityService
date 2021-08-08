using System.Collections.Generic;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ServiceOffer : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<EmployeeServiceOffered> EmployeeServiceOffered { get; set; }
        public virtual ICollection<ClientEmployees> ClientEmployees { get; set; }

        public ServiceOffer()
        {
        }

        public ServiceOffer(int id, string title, string details, bool status)
        {
            Id = id;
            Title = title;
            Details = details;
            Status = status;
        }
    }
}
