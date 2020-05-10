using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumManager.Extension
{
    internal static class JsonExtensions
    {
        public static object ToJsonObject(this string jsonText)
        { 
            return JsonConvert.DeserializeObject(jsonText);
        }

        public static string ToChecksumJson(this string jsonText, ushort checksum)
        { 
            JObject jsonObject = JObject.Parse(jsonText);

            if (jsonObject["Checksum"] == null)
                jsonObject.Add("Checksum", checksum);
            else
                jsonObject["Checksum"] = checksum;

            return jsonObject.ToString(Newtonsoft.Json.Formatting.None);  
        }

        public static string ToEmptyChecksumJson(this string jsonText)
        { 
            JObject jsonObject = JObject.Parse(jsonText);

            if (jsonObject["Checksum"] != null)
            {
                jsonObject["Checksum"] = 0;
            }  

            return jsonObject.ToString(Newtonsoft.Json.Formatting.None); 
        }
         
        public static object ToJsonWithoutChecksum(this string jsonText)
        { 
            JObject jsonObject = JObject.Parse(jsonText);

            if (jsonObject["Checksum"] != null)
                jsonObject.Remove("Checksum");

            return jsonObject; 
        }

        public static ushort ToChecksum(this string jsonText)
        { 
            JObject jsonObject = JObject.Parse(jsonText);

            if (jsonObject["Checksum"] != null)
                return Convert.ToUInt16(jsonObject["Checksum"]);
            else
                return 0; 
        }

        public static byte[] ToByteArray(this object obj)
        { 
            MemoryStream ms = new MemoryStream();

            using (BsonDataWriter writer = new BsonDataWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, obj);
            }

            return ms.ToArray();  
        }

    }
}
