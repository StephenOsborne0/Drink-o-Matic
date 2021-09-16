using System.IO;
using DrinksLibFramework.BusinessLogic.Serialization.Interfaces;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace DrinksLibFramework.BusinessLogic.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public void Serialize<T>(string filePath, object obj) where T : class
        {
            using(var sw = new StreamWriter(filePath))
                new Newtonsoft.Json.JsonSerializer { Formatting = Formatting.Indented}.Serialize(sw, obj);
        }

        public T Deserialize<T>(string filePath) where T : class
        {
            using(var sr = new StreamReader(filePath))
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
        }
    }
}