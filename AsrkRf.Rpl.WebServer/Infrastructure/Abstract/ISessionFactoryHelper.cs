using NHibernate;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Abstract
{
    public interface ISessionFactoryHelper
    {
        ISessionFactory GetSessionFactory { get; }
    }
}