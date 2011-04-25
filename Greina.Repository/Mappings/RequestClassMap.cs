using Greina.Core.Model;

namespace Greina.Repository.Mappings
{
    public class RequestClassMap : EntityBaseClassMap<Request>
    {
        public RequestClassMap()
        {
            Map(x => x.RequestedUrl);
            Map(x => x.UserAgent);
            Map(x => x.UserHostAddress);
            Map(x => x.UserHostName);
            Map(x => x.UserLanguages);
            Map(x => x.UrlRefferer);
        }
    }
}