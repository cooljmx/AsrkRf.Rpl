using NHibernate;

namespace AsrkRf.Rpl.Common
{
    public interface ISessionFactoryHelper
    {
        ISessionFactory GetSessionFactory { get; }
    }
}