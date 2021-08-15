using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StarSecurityService.ApplicationCore.DTO
{
    public class ServiceOfferViewModel
    {

        public string Title { get; set; }
        public string Details { get; set; }
        public HttpPostedFileBase[] Url { get; set; }
        public string Introduce { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public ServiceOfferViewModel()
        {
        }
    }
}
