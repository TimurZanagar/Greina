using FluentNHibernate.Mapping;
using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public sealed class RequestClassMap : ClassMap<Request>
    {
        public RequestClassMap()
        {
            Id(x => x.Id);

            Map(x => x.RequestedOn);
            Map(x => x.RequestedUrl);
            Map(x => x.UserAgent);
            Map(x => x.UserHostAddress);
            Map(x => x.UserHostName);
            Map(x => x.UserLanguages);
        }
    }
}