using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
     public  class CRC
    {
        public static void CRC16(byte[] data,int poly,ref byte  crcH,ref byte crcL )
        {
            int crc = 0xffff;
          
            for (int i = 0; i < data.Length; i++)
            {
                crc = data[i] ^ crc;
                for (int j = 0; j < 8; j++)
                {

                    if ((crc & 0x01) == 0x01)
                    {
                        crc = crc >> 1;
                        crc = crc ^ poly;
                    }
                    else
                        crc = crc >> 1;
                }


            }
            crcH = (byte)((crc & 0xff00) >> 8);
            crcL = (byte)(crc & 0x00ff);
        }

    }
}
