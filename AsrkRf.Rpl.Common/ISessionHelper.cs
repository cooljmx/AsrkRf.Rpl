using NHibernate;

namespace AsrkRf.Rpl.Common
{
    public interface ISessionHelper
    {
        ISession NewSession();
    }
}