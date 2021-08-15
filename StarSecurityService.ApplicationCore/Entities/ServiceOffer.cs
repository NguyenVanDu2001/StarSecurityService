using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class ServiceOffer : BaseEntity<int>
    {
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Details { get; set; }
        public string Url { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Introduce { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
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
