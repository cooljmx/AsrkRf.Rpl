using System;

namespace AsrkRf.Rpl.Common
{
    public interface ITypeResolver
    {
        object Resolve(Type interfaceType);
    }
}
