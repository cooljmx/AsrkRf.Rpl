using System;

namespace AsrkRf.Rpl.Common
{
    public class CommonEntity
    {
        public string GetProperty(string property)
        {
            return GetType().GetProperty(property).GetValue(this, null).ToString();
        }

        public void SetProperty(string property, IConvertible value)
        {
            var prop = GetType().GetProperty(property);
            object convertedValue = null;
            if (prop.PropertyType == typeof(int)) convertedValue = value.ToInt32(null);
            if (prop.PropertyType == typeof(decimal)) convertedValue = value.ToDecimal(null);
            if (prop.PropertyType == typeof(long)) convertedValue = value.ToInt64(null);
            if (prop.PropertyType == typeof(DateTime)) convertedValue = value.ToDateTime(null);

            prop.SetValue(this, convertedValue, null);
        }

        public object CreateInstance()
        {
            return Activator.CreateInstance(GetType());
        }
    }
}
