using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsrkRf.Rpl.Common
{
    public interface IProvider
    {
        ICloud Get(decimal id);
        void Post(ICloud value);
    }

    /*public interface ISubdivisionProvider : IProvider
    {
        //CloudSubdivision Get(long id);
        void Post(string value);
    }*/
}
