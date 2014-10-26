using System.Web.Http;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;
using AsrkRf.Rpl.Subdivision;

namespace AsrkRf.Rpl.WebServer.Controllers
{
    public class SubdivisionController : ApiController
    {
        private readonly FirebirdSubdivisionProvider provider;

        public SubdivisionController(ISessionHelper sessionHelper, IUriHelper uriHelper)
        {
            provider = new FirebirdSubdivisionProvider(sessionHelper, uriHelper);
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
