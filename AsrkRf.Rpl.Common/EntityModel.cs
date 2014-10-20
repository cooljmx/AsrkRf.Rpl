using System.Xml.Serialization;

namespace AsrkRf.Rpl.Common
{
    [XmlType(TypeName = "Entity")]
    public class EntityModel : VirtualNotifyPropertyChanged
    {
        private string className;
        private string sqlText;

        public string ClassName { get { return className; } set { className = value; NotifyPropertyChanged("ClassName"); } }
        public string SqlText { get { return sqlText; } set { sqlText = value; NotifyPropertyChanged("SqlText"); } }
    }
}
