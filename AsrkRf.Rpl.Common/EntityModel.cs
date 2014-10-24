using System.Xml.Serialization;

namespace AsrkRf.Rpl.Common
{
    [XmlType(TypeName = "Entity")]
    public class EntityModel : VirtualNotifyPropertyChanged
    {
        private string className;
        private string sqlText;
        private bool isList;
        private string objectName;

        public string ClassName { get { return className; } set { className = value; NotifyPropertyChanged("ClassName"); } }
        public string SqlText { get { return sqlText; } set { sqlText = value; NotifyPropertyChanged("SqlText"); } }
        public bool IsList { get { return isList; } set { isList = value; NotifyPropertyChanged("IsList"); } }
        public string ObjectName { get { return objectName; } set { objectName = value; NotifyPropertyChanged("ObjectName"); } }
    }
}
