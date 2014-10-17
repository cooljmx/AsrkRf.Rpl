using System;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Subdivision.Cloud;

namespace AsrkRf.Rpl.Subdivision
{
    internal class SubdivisionTypeResolver : ITypeResolver
    {
        public object Resolve(Type interfaceType)
        {
            if (interfaceType.IsAssignableFrom(typeof (ICloudSubdivision))) return new CloudSubdivision();
            throw new Exception("Резолвер типов не смог определить тип");
        }
    }
}
