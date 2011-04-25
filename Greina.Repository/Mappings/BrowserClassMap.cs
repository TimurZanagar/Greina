using FluentNHibernate.Mapping;
using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public sealed class BrowserClassMap : ClassMap<Browser>
    {
        public BrowserClassMap()
        {
            Id(x => x.Id);
        }
    }
}