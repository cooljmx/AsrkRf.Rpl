using System.Reflection;
using System.Web.Configuration;
using System.Web.Hosting;
using AsrkRf.Rpl.WebServer.Infrastructure.Abstract;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Concrete
{
    public class SessionFactoryHelper : ISessionFactoryHelper
    {
        private readonly ISessionFactory sessionFactory;

        // TODO: Сделать SessionFactoryHelper синглтоном уровня приложения
        public SessionFactoryHelper()
        {
            var root = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            var connectionString = root.AppSettings.Settings["ConnectionString"];
            
            var cfg = MsSqlConfiguration.MsSql2012; //FirebirdConfiguration();

            log4net.Config.XmlConfigurator.Configure(); 
            sessionFactory = Fluently.Configure()
                .Database(cfg.ConnectionString(connectionString.Value).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ExtReg.Entities")))
                .Diagnostics(x => x.Enable())
                .BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory { get { return sessionFactory; } }
    }
}