using NHibernate;

namespace CompetitorReg.Infrastructure.Abstract
{
    public interface ISessionFactoryHelper
    {
        ISessionFactory GetSessionFactory { get; }
    }
}