using System.IO;
using DrinksLibFramework.BusinessLogic.Serialization.Interfaces;

namespace DrinksLibFramework.BusinessLogic.Serialization
{
    public class Serialization
    {
        private static ISerializer _serializer = new XmlSerializer();

        private static void SetSerializer(string filePath)
        {
            switch (Path.GetExtension(filePath))
            {
                case ".xml":
                    _serializer = new XmlSerializer();
                    break;
                case ".json":
                    _serializer = new JsonSerializer();
                    break;
                default:
                    _serializer = new XmlSerializer();
                    break;
            }
        }

        public static void Serialize<T>(string filePath, object obj)
            where T : class
        {
            SetSerializer(filePath);
            _serializer.Serialize<T>(filePath, obj);
        }

        public static T Deserialize<T>(string filePath)
            where T : class
        {
            SetSerializer(filePath);
            return _serializer.Deserialize<T>(filePath);
        }
    }
}