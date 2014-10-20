using AsrkRf.Rpl.Common;
using CompetitorReg.Infrastructure.Abstract;
using NHibernate;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Concrete
{
    public class SessionHelper : ISessionHelper{
        private readonly ISessionFactoryHelper sessionFactoryHelper;
        public SessionHelper(ISessionFactoryHelper sessionFactoryHelper)
        {
            this.sessionFactoryHelper = sessionFactoryHelper;
        }

        public ISession NewSession()
        {
            return sessionFactoryHelper.GetSessionFactory.OpenSession();
        }
    }
}