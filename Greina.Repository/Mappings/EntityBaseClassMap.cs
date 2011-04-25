using FluentNHibernate.Mapping;
using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public class EntityBaseClassMap<T> : ClassMap<T> where T : EntityBase
    {
        public EntityBaseClassMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();

            Version(x => x.Version);
            Map(x => x.CreatedOn);
        }
    }
}