using System;
using System.Linq;
using System.Reflection;
using AsrkRf.Rpl.Common;

namespace AsrkRf.Rpl.Reflector
{
    public class DirectReflector
    {
        private readonly ITypeResolver typeResolver;
        public DirectReflector(ITypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
        }

        public void Fill(object src, object dst)
        {
            var dstType = dst.GetType();
            var srcType = src.GetType();

            foreach (var propertyInfo in srcType.GetProperties())
            {
                var customAttributes = propertyInfo.GetCustomAttributes(false);
                var cloudAttribute = (CloudAttribute)customAttributes.FirstOrDefault(x => x.GetType().IsAssignableFrom(typeof(CloudAttribute)));

                if (cloudAttribute != null)
                {
                    var srcValue = propertyInfo.GetValue(src, null);
                    var dstPropertyInfo = dstType.GetProperty(cloudAttribute.PropertyName);

                    switch (cloudAttribute.Type)
                    {
                        case CloudAttributeType.Value:
                            dstPropertyInfo.SetValue(dst, Convert.ChangeType(srcValue, dstPropertyInfo.PropertyType), null);
                            break;
                        case CloudAttributeType.List:
                            FillList(srcValue, dst, dstPropertyInfo);
                            break;
                        case CloudAttributeType.Class:
                            FillClass(srcValue, dst, dstPropertyInfo);
                            break;
                    }
                }
            }
        }

        private void FillList(object src, object dst, PropertyInfo dstPropertyInfo)
        {
           
        }

        private void FillClass(object srcPropertyValue, object dst, PropertyInfo dstPropertyInfo)
        {
            if (srcPropertyValue == null) return;
            var dstPropertyType = dstPropertyInfo.PropertyType;
            var dstPropertyValue = typeResolver.Resolve(dstPropertyType);
            dstPropertyInfo.SetValue(dst, dstPropertyValue, null);
            Fill(srcPropertyValue, dstPropertyValue);
        }

    }
}
