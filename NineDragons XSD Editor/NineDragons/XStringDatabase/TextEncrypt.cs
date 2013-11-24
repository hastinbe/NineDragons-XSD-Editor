using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NineDragons.XStringDatabase
{
    public class TextEncrypt
    {
        /// <summary>
        /// Xor's a byte array using two keys. The key is alternated each byte.
        /// </summary>
        public static byte[] BikeyXor(byte[] buffer, byte[] key)
        {
            return BikeyXor(buffer, GetPaddedByteStringLength(buffer), key);
        }

        /// <summary>
        /// Xor's a byte array using two keys. The key is alternated each byte.
        /// </summary>
        public static byte[] BikeyXor(byte[] buffer, int len, byte[] key)
        {
            for (int i = 0; i < len; i++)
                buffer[i] = (byte)(buffer[i] ^ key[i % 2]);
            return buffer;
        }

        public static int GetPaddedByteStringLength(byte[] str)
        {
            for (int i = 0; i < str.Length; i += 2)
                if (str[i] == 0)
                    return i;
            return str.Length;
        }
    }
}
