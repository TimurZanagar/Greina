using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Greina.Repository.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Greina.Repository
{
    public class SessionFactoryService
    {
        public static readonly ISessionFactory SessionFactory = BuildSessionFactory();

        public static ISessionFactory BuildSessionFactory()
        {
            return CreateConfiguration().BuildSessionFactory();
        }

        public static FluentConfiguration CreateConfiguration()
        {
            return
                Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ApplicationServices"))
                                  .ShowSql()
                                  .FormatSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RequestClassMap>())
                    .ExposeConfiguration(cfg =>
                    {
                        cfg.Properties.Add("hibernate.hbm2ddl.auto", "validate");
                        cfg.BuildMappings();
                        //new SchemaExport(cfg)
                        //    .SetOutputFile(@"C:\Users\TZ\Desktop\Greina.sql")
                        //    .Execute(false, false, false);
                        new SchemaUpdate(cfg).Execute(true, true);
                    });
        }
    }
}