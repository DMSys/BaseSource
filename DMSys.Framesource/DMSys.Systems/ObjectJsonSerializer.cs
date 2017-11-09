using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DMSys.Systems
{
    public static class ObjectJsonSerializer
    {
        public static string Serialize<T>(T graph)
        {
            string jsonString = "";
            using (MemoryStream mStream = new MemoryStream())
            {
                DataContractJsonSerializer dcJson = new DataContractJsonSerializer(typeof(T));
                dcJson.WriteObject(mStream, graph);

                jsonString = Encoding.UTF8.GetString(mStream.ToArray());
            }
            return jsonString;
        }

        public static T Deserialize<T>(string json)
        {
            T graph;
            using (MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                graph = (T)serializer.ReadObject(mStream);
            }
            return graph;
        }
    }
}
