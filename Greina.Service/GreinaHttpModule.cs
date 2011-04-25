using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Greina.Core.Model;
using Greina.Repository;
using NHibernate;
using NHibernate.Linq;

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

            // TODO: Set Application Name from web.config
            string applicationName = "www.greina.de";
            string cookieName = string.Format("Greina_{0}", applicationName);

            Guid visitorId;

            HttpCookie cookie = application.Request.Cookies[cookieName];

            if (cookie != null)
            {
                visitorId = Guid.Parse(cookie["VisitorId"]);

                using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            Guid requestId = Guid.NewGuid();

                            var request = new Request
                                              {
                                                  Id = requestId,
                                                  CreatedOn = DateTime.UtcNow,
                                                  RequestedUrl = requestedUrl,
                                                  UserAgent = application.Request.UserAgent,
                                                  UserHostAddress = application.Request.UserHostAddress,
                                                  UserHostName = application.Request.UserHostName,
                                                  UserLanguages = application.Request.UserLanguages,
                                                  UrlRefferer =
                                                      application.Request.UrlReferrer != null
                                                          ? application.Request.UrlReferrer.ToString()
                                                          : string.Empty
                                              };

                            Visitor visitor =
                                (from x in session.Query<Visitor>() where x.Id == visitorId select x).FirstOrDefault();

                            if (visitor.Requests == null)
                            {
                                visitor.Requests = new List<Request>();
                            }


                            session.SaveOrUpdate(request);
                            visitor.Requests.Add(session.Get<Request>(requestId));
                            session.SaveOrUpdate(visitor);

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            application.Request.Cookies.Remove(applicationName);
                            throw;
                        }
                    }
                }
            }
            else
            {
                cookie = new HttpCookie(cookieName);

                visitorId = Guid.NewGuid();
                cookie["VisitorId"] = visitorId.ToString();
                cookie.Expires = DateTime.MaxValue;

                application.Response.Cookies.Add(cookie);

                using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            Guid requestId = Guid.NewGuid();

                            var request = new Request
                                              {
                                                  Id = requestId,
                                                  CreatedOn = DateTime.UtcNow,
                                                  RequestedUrl = requestedUrl,
                                                  UserAgent = application.Request.UserAgent,
                                                  UserHostAddress = application.Request.UserHostAddress,
                                                  UserHostName = application.Request.UserHostName,
                                                  UserLanguages = application.Request.UserLanguages,
                                                  UrlRefferer =
                                                      application.Request.UrlReferrer != null
                                                          ? application.Request.UrlReferrer.ToString()
                                                          : string.Empty
                                              };

                            var visitor = new Visitor {Id = visitorId, CreatedOn = DateTime.UtcNow};

                            if (visitor.Requests == null)
                            {
                                visitor.Requests = new List<Request>();
                            }

                            session.SaveOrUpdate(request);
                            visitor.Requests.Add(session.Get<Request>(requestId));
                            session.SaveOrUpdate(visitor);

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            application.Request.Cookies.Remove(applicationName);
                            throw;
                        }
                    }
                }
            }
        }

        #endregion
    }
}