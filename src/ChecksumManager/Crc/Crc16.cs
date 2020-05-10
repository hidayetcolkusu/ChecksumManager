using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumManager.Crc
{
    internal class Crc16
    {
        private const ushort polynomial = 0xA001;
        private static readonly ushort[] refTable = new ushort[256];

        public Crc16()
        {
            GenerateReferanceTable();
        }

        private void GenerateReferanceTable()
        {
            ushort value;
            ushort temp;

            for (ushort i = 0; i < refTable.Length; ++i)
            {
                value = 0;
                temp = i;

                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }

                    temp >>= 1;
                }

                refTable[i] = value;
            }
        }

        public ushort Calculate(byte[] bytes)
        { 
            ushort crc = 0; 
             
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ refTable[index]);
            } 

            return crc;
        }

    }
}
