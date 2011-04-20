using System;
using System.Web;

namespace Greina.Core
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

        static void ContextBeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;

            string requestedUrl = application.Request.Url.ToString();

            if (string.IsNullOrWhiteSpace(requestedUrl))
            {
                return;
            }

            string userAgent = application.Request.UserAgent;
            string userHostAddress = application.Request.UserHostAddress;
            string userHostName = application.Request.UserHostName;
            string[] userLanguages = application.Request.UserLanguages;
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}