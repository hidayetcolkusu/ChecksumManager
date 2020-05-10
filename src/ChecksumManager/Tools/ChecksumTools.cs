using System;
using System.Collections.Generic;
using System.Linq; 
using Newtonsoft.Json; 
using System.Data; 
using System.Reflection;
using ChecksumManager.Extension;

namespace ChecksumManager.Tools
{
    internal class ChecksumTools
    {
        public PropertyInfo GetChecksumPropertyInfo<T>(T obj)
        {
            Type objType = obj.GetType();

            return new List<PropertyInfo>(objType.GetProperties()).Where(x => x.Name == "Checksum").FirstOrDefault();
        }

        public ushort GetChecksum<T>(T obj, PropertyInfo prop)
        { 
            return Convert.ToUInt16(prop.GetValue(obj, null)); 
        }

        public void SetChecksum<T>(T obj, PropertyInfo prop, ushort checksum)
        {
            prop.SetValue(obj, checksum, null);
        }

        public byte[] GetByteArray<T>(T obj)
        { 
            return JsonConvert.SerializeObject(obj).ToJsonObject().ToByteArray();
        }

        public byte[] GetByteArray(string jsonText)
        { 
            return jsonText.ToJsonObject().ToByteArray();
        }

    }
}
