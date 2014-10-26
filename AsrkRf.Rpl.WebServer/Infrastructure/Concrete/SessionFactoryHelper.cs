using System;
using System.Reflection;
using System.Configuration;
using AsrkRf.Rpl.Session;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Concrete
{
    public class SessionFactoryHelper : ISessionFactoryHelper
    {
        private readonly ISessionFactory sessionFactory;

        public SessionFactoryHelper()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var connectionProvider = ConfigurationManager.AppSettings["ConnectionProvider"];

            IPersistenceConfigurer cfg = null;

            switch (connectionProvider)
            {
                case "Firebird":
                    cfg = (new FirebirdConfiguration()).ConnectionString(connectionString).ShowSql();
                    break;
                case "MsSqlServer":
                    cfg = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql();
                    break;
            }

            //log4net.Config.XmlConfigurator.Configure();
            try
            {
                sessionFactory = Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("AsrkRf.Rpl.Subdivision")))
                    .Diagnostics(x => x.Enable())
                    .BuildSessionFactory();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public ISessionFactory GetSessionFactory { get { return sessionFactory; } }
    }
}