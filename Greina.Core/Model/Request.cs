using System;

namespace Greina.Core.Model
{
    public class Request
    {
        public Guid Id { get; set; }
        public string RequestedUrl { get; set; }
        public string UserAgent { get; set; }
        public string UserHostAddress { get; set; }
        public string UserHostName { get; set; }
        public string[] UserLanguages { get; set; }
    }
}