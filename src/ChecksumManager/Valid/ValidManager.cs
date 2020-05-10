using ChecksumManager.Exceptions;
using ChecksumManager.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumManager.Valid
{
    internal class ValidManager
    {

        public void ValidObject<T>(T obj, bool validChecksum = false)
        { 
            CheckIsObjNull(obj);

            CheckIsObjCanConvertJson(obj);

            if (validChecksum)
            {
                IsExistsChecksumProp(obj);

                CheckIsValidChecksumPropType(obj);
            }
        }

        public void ValidByteArray(byte[] bytes, int startIndex = -1, bool isValidIndex = false)
        {
            CheckIsValidByteArray(bytes);

            if (isValidIndex)
                CheckIsByteArrayExistsIndex(bytes, startIndex);
        }

        public void ValidJson(string jsonText, bool validChecksum = false)
        {
            CheckIsJson(jsonText);

            if (validChecksum)
                CheckIsJsonExistsChecksum(jsonText);
        }




        private void CheckIsObjNull<T>(T obj)
        {
            if (obj.IsObjNull())
                throw new ChecksumException("This object can not be null.");
        }

        private void CheckIsObjCanConvertJson<T>(T obj)
        { 
            if (!obj.IsObjCanConvertJson())
                throw new ChecksumException("This object can not convert to json.");
        }

        private void IsExistsChecksumProp<T>(T obj)
        {
            if (!obj.IsExistsChecksumProp())
                throw new ChecksumException("This object does not exists checksum property.");
        }

        private void CheckIsValidChecksumPropType<T>(T obj)
        {
            if (!obj.IsValidChecksumPropType())
                throw new ChecksumException("The checksum data type is invalid.");
        }
         
        private void CheckIsValidByteArray(byte[] bytes)
        {
            if (!bytes.IsValidByteArray())
                throw new ChecksumException("The byte array can not be null.");
        }

        private void CheckIsByteArrayExistsIndex(byte[] bytes, int startIndex)
        {
            if (!bytes.IsByteArrayExistsIndex(startIndex))
                throw new ChecksumException("Invalid checksum index.");
        }

        private void CheckIsJson(string jsonText)
        {
            if (!jsonText.IsJson())
                throw new ChecksumException("This string isnt json.");
        }

        private void CheckIsJsonExistsChecksum(string jsonText)
        {
            if (!jsonText.IsJsonExistsChecksum())
                throw new ChecksumException("This string does not exists json.");
        }


         

    }
}
