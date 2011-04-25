using System;

namespace Greina.Core.Model
{
    public class EntityBase
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
    }
}