using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AsrkRf.Rpl.WebServer.Controllers
{
    public class TestController : ApiController
    {
        public int Get(int id)
        {
            return id;
        }
    }
}
