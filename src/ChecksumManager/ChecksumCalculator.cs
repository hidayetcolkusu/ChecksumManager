using ChecksumManager.Crc;
using ChecksumManager.Exceptions;
using ChecksumManager.Extension;
using ChecksumManager.Tools;
using ChecksumManager.Valid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ChecksumManager
{
    public class ChecksumCalculator
    {
        private Crc16 _crc16;
        private ChecksumTools _checksumTools;
        private ValidManager _validManager;

        public ChecksumCalculator()
        {
            _crc16         = new Crc16();
            _checksumTools = new ChecksumTools();
            _validManager  = new ValidManager();
        }
       
       
        public byte[] GetByteArray<T>(T obj)
        {
            _validManager.ValidObject(obj);

            return _checksumTools.GetByteArray(obj);
        }
         
        public ushort Calculate(byte[] bytes)
        {
            _validManager.ValidByteArray(bytes);

            return _crc16.Calculate(bytes);
        }
        
        public ushort Calculate<T>(T obj)
        {
            _validManager.ValidObject(obj);

            return Calculate(_checksumTools.GetByteArray(obj));
        }
       
        public ushort Calculate(string jsonText)
        {
            _validManager.ValidJson(jsonText);

            return Calculate(_checksumTools.GetByteArray(jsonText)); 
        }

        public bool Compare(byte[] bytes, ushort checksum)
        {
            _validManager.ValidByteArray(bytes);

            return Calculate(bytes) == checksum;
        }
        
        public bool Compare(byte[] bytes, int startIndex)
        {
            _validManager.ValidByteArray(bytes, startIndex, true);

            ushort checksum = BitConverter.ToUInt16(bytes, startIndex);

            new byte[] { 0, 0 }.CopyTo(bytes, startIndex);

            return checksum == Calculate(bytes);
        }
       
        public bool Compare<T>(T obj, ushort checksum)
        {
            _validManager.ValidObject(obj);

            return Calculate(obj) == checksum;
        }
        
        public bool Compare<T>(T obj)
        {
            _validManager.ValidObject(obj, true);

            bool result = false;
             
            PropertyInfo prop = _checksumTools.GetChecksumPropertyInfo(obj);
            ushort checksum = _checksumTools.GetChecksum(obj, prop);
            _checksumTools.SetChecksum(obj, prop, 0);
            result = Calculate(obj) == checksum;
            _checksumTools.SetChecksum(obj, prop, checksum);

            return result;
        }

        public bool Compare(string jsonText, ushort checksum)
        {
            _validManager.ValidJson(jsonText);

            return Calculate(jsonText) == checksum;
        }
        
        public bool Compare(string jsonText)
        {
            _validManager.ValidJson(jsonText, true);

            bool result = false;

            ushort jsonChecksum = jsonText.ToChecksum(); 

            result = jsonChecksum == Calculate(jsonText.ToJsonWithoutChecksum());

            if (!result)
                result = jsonChecksum == Calculate(jsonText.ToEmptyChecksumJson());

            return result;
        }
       
        public T Fill<T>(T obj)
        {
            _validManager.ValidObject(obj, true);

            PropertyInfo prop = _checksumTools.GetChecksumPropertyInfo(obj);
            ushort checksum = Calculate(obj);
            _checksumTools.SetChecksum(obj, prop, checksum);

            return obj;
        }
        
        public byte[] Fill(byte[] bytes, int startIndex)
        {
            _validManager.ValidByteArray(bytes, startIndex, true);

            ushort checksum = Calculate(bytes);

            byte[] checksumBytes = BitConverter.GetBytes(checksum);

            if (checksumBytes.Count() == 2)
            {
                checksumBytes.CopyTo(bytes, startIndex);
            }

            return bytes;
        }
        
        public string Fill(string jsonText)
        {
            _validManager.ValidJson(jsonText);

            return jsonText.ToChecksumJson(Calculate(jsonText)); 
        }  
    }
}
