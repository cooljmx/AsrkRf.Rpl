using NHibernate;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Abstract
{
    public interface ISessionHelper
    {
        ISession NewSession();
    }
}