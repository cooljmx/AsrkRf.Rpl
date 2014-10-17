using System;
using System.Collections.Generic;
using System.Web.Http;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Subdivision;

namespace AsrkRf.Rpl.WebServer.Controllers
{
    public class SubdivisionController : ApiController
    {
        private readonly ISubdivisionProvider provider;

        public SubdivisionController(ISessionHelper sessionHelper)
        {
            provider = new SubdivisionProvider(sessionHelper);
        }

        public IEnumerable<ICloudSubdivision> Get()
        {
            return null;
        }

        public ICloudSubdivision Get(long id)
        {
            return provider.Get(id);
        }
    }
}
