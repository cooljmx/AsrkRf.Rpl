using System;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Reflector;
using AsrkRf.Rpl.Subdivision.Cloud;
using AsrkRf.Rpl.Subdivision.Entities;

namespace AsrkRf.Rpl.Subdivision
{
    public class SubdivisionProvider : ISubdivisionProvider
    {
        private readonly ISessionHelper sessionHelper;
        private readonly ITypeResolver typeResolver;
        public SubdivisionProvider(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
            this.typeResolver = new SubdivisionTypeResolver();
        }

        public ICloudSubdivision Get(long id)
        {
            using (var session = sessionHelper.NewSession())
            {
                try
                {
                    var src = session.Get<Podrazdelenie>(id);
                    var dst = new CloudSubdivision();
                    var reflector = new DirectReflector(typeResolver);
                    reflector.Fill(src, dst);
                    return dst;
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }
    }
}
