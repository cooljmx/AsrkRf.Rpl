using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsrkRf.Rpl.Common
{
    public interface IProvider
    {
    }

    public interface ISubdivisionProvider : IProvider
    {
        ICloudSubdivision Get(long id);
        void Post(string value);
    }
}
