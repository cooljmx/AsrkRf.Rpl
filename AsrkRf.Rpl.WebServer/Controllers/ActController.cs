using System.Web.Http;
using AsrkRf.Rpl.Act;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;

namespace AsrkRf.Rpl.WebServer.Controllers
{
    public class ActController : ApiController
    {
        private readonly FirebirdActProvider provider;

        public ActController(ISessionHelper sessionHelper, IUriHelper uriHelper)
        {
            provider = new FirebirdActProvider(sessionHelper, uriHelper);
        }

        public object Get(long id)
        {
            return provider.Get(id);
        }

        public void Post([FromBody]string value)
        {
            provider.Post(value);
        }
    }
}
