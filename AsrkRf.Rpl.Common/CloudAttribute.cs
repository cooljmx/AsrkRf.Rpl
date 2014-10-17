using System;

namespace AsrkRf.Rpl.Common
{
    public enum CloudAttributeType
    {
        Value, Class, List
    }

    public class CloudAttribute : Attribute
    {
        public string ClassName { get; set; }
        public string PropertyName { get; set; }
        public CloudAttributeType Type { get; set; }
    }
}
