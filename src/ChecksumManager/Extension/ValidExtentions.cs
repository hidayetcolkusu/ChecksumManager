using ChecksumManager.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumManager.Extension
{
    public static class ValidExtentions
    { 
        public static bool IsJson(this string jsonText)
        {
            try
            {
                JToken.Parse(jsonText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsJsonExistsChecksum(this string jsonText)
        {
            if (jsonText.IsJson())
            {
                JObject jsonObject = JObject.Parse(jsonText);

                return (jsonObject["Checksum"] != null);
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidObjToConvertByteArray<T>(this T obj)
        {
            return (!obj.IsObjNull() && obj.IsObjCanConvertJson());
        }

        public static bool IsExistsChecksumProp<T>(this T obj)
        {
            var prop = new ChecksumTools().GetChecksumPropertyInfo(obj);
             
            return (prop != null);
        }

        public static bool IsValidChecksumPropType<T>(this T obj)
        {
            var prop = new ChecksumTools().GetChecksumPropertyInfo(obj);

            if (prop != null)
                return prop.IsValidChecksumPropType();
            else
                return false;
        }

        public static bool IsObjNull<T>(this T obj)
        {
            return obj == null;
        }

        public static bool IsObjCanConvertJson<T>(this T obj)
        {
            bool result = false;

            try
            {
                byte[] bytes = JsonConvert.SerializeObject(obj).ToJsonObject().ToByteArray();

                if (bytes.Count() > 0)
                    result = true;
            }
            catch  
            {
                 
            }

            return result;
        }

        public static bool IsValidChecksumPropType(this PropertyInfo prop)
        { 
            ushort value = 0; 

            return (value.GetType() == prop.PropertyType);
        }

        public static bool IsValidByteArray(this byte[] bytes)
        {
            return bytes != null;
        }

        public static bool IsByteArrayExistsIndex(this byte[] bytes, int startIndex)
        {
            if (bytes.IsValidByteArray())
                return bytes.Count() >= startIndex;
            else
                return false; 
        }

    }
}
