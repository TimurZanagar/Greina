using System;
using System.Web;
using Greina.Core;
using Greina.Core.Model;
using Greina.Repository;

namespace Greina.Service
{
    public class GreinaHttpModule : IHttpModule
    {
        #region Implementation of IHttpModule

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += ContextBeginRequest;
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        private static void ContextBeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;

            string requestedUrl = application.Request.Url.ToString();

            if (string.IsNullOrWhiteSpace(requestedUrl))
            {
                return;
            }

            IGreinaRepository greinaRepository = new GreinaRepository();

            var request = new Request
                              {
                                  RequestedOn = DateTime.UtcNow,
                                  RequestedUrl = requestedUrl,
                                  UserAgent = application.Request.UserAgent,
                                  UserHostAddress = application.Request.UserHostAddress,
                                  UserHostName = application.Request.UserHostName,
                                  UserLanguages = application.Request.UserLanguages
                              };

            greinaRepository.Save(request);
        }

        #endregion
    }
}