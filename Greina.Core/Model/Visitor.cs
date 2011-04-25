using System.Collections.Generic;

namespace Greina.Core.Model
{
    public class Visitor : EntityBase
    {
        public virtual IList<Request> Requests { get; set; }
    }
}