using System;

namespace Greina.Core.Model
{
    public class Request
    {
        public virtual Guid Id { get; set; }
        public virtual string RequestedUrl { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual string UserHostAddress { get; set; }
        public virtual string UserHostName { get; set; }
        public virtual string[] UserLanguages { get; set; }
    }
}