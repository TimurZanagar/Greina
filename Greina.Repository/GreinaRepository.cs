using System;
using Greina.Core;
using Greina.Core.Model;
using NHibernate;

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

        #endregion
    }
}