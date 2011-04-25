using System;
using System.Linq;
using Greina.Core;
using Greina.Core.Model;
using NHibernate;
using NHibernate.Linq;

namespace Greina.Repository
{
    public class GreinaRepository : IGreinaRepository
    {
        #region IGreinaRepository Members

        public void Save(Request request)
        {
            using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(request);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool VisitorExistsById(Guid visitorId)
        {
            bool result;

            using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Visitor visitor =
                            (from x in session.Query<Visitor>() where x.Id == visitorId select x).FirstOrDefault();

                        result = visitor != null;

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return result;
        }

        public void CreateVisitor(Guid visitorId)
        {
            using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var visitor = new Visitor {Id = visitorId};

                        session.Save(visitor);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Visitor GetVisitorById(Guid visitorId)
        {
            Visitor visitor;

            using (ISession session = SessionFactoryService.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        visitor = (from x in session.Query<Visitor>() where x.Id == visitorId select x).FirstOrDefault();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return visitor;
        }

        #endregion
    }
}