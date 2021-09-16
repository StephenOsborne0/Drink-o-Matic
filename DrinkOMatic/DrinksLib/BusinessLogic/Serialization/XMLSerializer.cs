using System.IO;

namespace DrinksLib.Helpers
{
    public class XmlSerializer : ISerializer
    {
        public void Serialize<T>(string filePath, object obj) where T : class
        {
            using (var sw = new StreamWriter(filePath))
                new System.Xml.Serialization.XmlSerializer(typeof(T)).Serialize(sw, obj);
        }

        public T Deserialize<T>(string filePath) where T : class
        {
            using (var sr = new StreamReader (filePath))
                return (T)new System.Xml.Serialization.XmlSerializer (typeof (T)).Deserialize (sr);
        }
    }
}