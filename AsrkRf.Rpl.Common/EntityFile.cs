using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AsrkRf.Rpl.Common
{
    [XmlRoot("Entities")]
    public class EntityFile : List<EntityModel>
    {
        public void SaveToFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof (EntityFile));
                serializer.Serialize(stream, this);
            }
        }

        public static EntityFile LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof (EntityFile));
                return (EntityFile) serializer.Deserialize(stream);
            }
        }
    }
}
