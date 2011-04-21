using Greina.Repository;
using NHibernate;
using NUnit.Framework;

namespace Greina.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CanCreateDatabaseScript()
        {
            ISessionFactory sessionFactory = SessionFactoryService.BuildSessionFactory();

            Assert.IsNotNull(sessionFactory);
        }
    }
}