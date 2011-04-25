using FluentNHibernate.Mapping;
using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public sealed class VisitorClassMap : ClassMap<Visitor>
    {
        public VisitorClassMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Requests).KeyColumn("VisitorId");
        }
    }
}