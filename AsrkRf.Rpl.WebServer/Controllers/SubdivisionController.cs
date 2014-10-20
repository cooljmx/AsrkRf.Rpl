using System.Web.Http;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Subdivision;

namespace AsrkRf.Rpl.WebServer.Controllers
{
    public class SubdivisionController : ApiController
    {
        private readonly IProvider provider;

        public SubdivisionController(ISessionHelper sessionHelper)
        {
            provider = new SubdivisionProvider(sessionHelper);
        }

        public ICloud Get(long id)
        {
            return provider.Get(id);
        }

        public void Post([FromBody]ICloud value)
        {
            provider.Post(value);
        }
    }
}
