using NHibernate;

namespace AsrkRf.Rpl.Session
{
    public interface ISessionHelper
    {
        ISession NewSession();
    }
}