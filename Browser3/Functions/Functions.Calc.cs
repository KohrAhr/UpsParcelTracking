using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser3.Functions
{
    public static class CalcFunctions
    {
        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint CalculateCRC32(string input)
        {
            uint crc32 = 0xFFFFFFFF; // Initial CRC32 value

            byte[] bytes = Encoding.UTF8.GetBytes(input);

            foreach (byte b in bytes)
            {
                crc32 ^= (uint)b;

                for (int i = 0; i < 8; i++)
                {
                    if ((crc32 & 1) == 1)
                    {
                        crc32 = (crc32 >> 1) ^ 0xEDB88320; // CRC32 polynomial
                    }
                    else
                    {
                        crc32 >>= 1;
                    }
                }
            }

            crc32 ^= 0xFFFFFFFF; // Invert the final CRC32 value

            return crc32;
        }

    }
}
