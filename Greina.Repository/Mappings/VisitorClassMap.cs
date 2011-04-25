using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public sealed class VisitorClassMap : EntityBaseClassMap<Visitor>
    {
        public VisitorClassMap()
        {
            HasMany(x => x.Requests).KeyColumn("VisitorId");
        }
    }
}