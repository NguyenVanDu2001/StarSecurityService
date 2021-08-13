using System.Collections.Generic;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ServiceOffer : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public string Introduce { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<EmployeeServiceOffered> EmployeeServiceOffered { get; set; }
        public virtual ICollection<ClientEmployees> ClientEmployees { get; set; }

        public ServiceOffer(int id, string title, string details, string url, string introduce, string description, bool status)
        {
            Id = id;
            Title = title;
            Details = details;
            Url = url;
            Introduce = introduce;
            Description = description;
            Status = status;
        }
        public ServiceOffer()
        {

        }
    }
}
