using NHibernate;

namespace AsrkRf.Rpl.Session
{
    public interface ISessionFactoryHelper
    {
        ISessionFactory GetSessionFactory { get; }
    }
}