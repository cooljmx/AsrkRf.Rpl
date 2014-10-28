using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;

namespace AsrkRf.Rpl.Act
{
    public class FirebirdActProvider : IFirebird
    {
        private readonly ISessionHelper sessionHelper;
        private readonly IUriHelper uriHelper;

        public FirebirdActProvider(ISessionHelper sessionHelper, IUriHelper uriHelper)
        {
            this.sessionHelper = sessionHelper;
            this.uriHelper = uriHelper;
        }

        public object Get(decimal id)
        {
            return null;
        }

        public void Post(string value)
        {
        }
    }
}
