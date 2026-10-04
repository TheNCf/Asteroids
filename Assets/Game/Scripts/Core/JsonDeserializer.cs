using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.Core
{
    public static class JsonDeserializer
    {
        public static T Parse<T>(TextAsset jsonFile)
        {
            if (jsonFile == null)
                throw new FileNotFoundException();
            
            T output = JsonConvert.DeserializeObject<T>(jsonFile.text);
            return output;
        }
    }
}