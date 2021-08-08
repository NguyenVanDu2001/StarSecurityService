using StarSecurityService.ApplicationCore.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace StarSecurityService.Web.Commons
{
    public class Response<T>
    {
        public T Data { get; set; }
        public  string Error { get; set; }
        public  string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public StatusEnum Status { get; set; } = StatusEnum.Succeeded;
    }
}