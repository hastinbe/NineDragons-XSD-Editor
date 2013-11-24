//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Collections.Generic;
using System.Text;

namespace NineDragons_XSD_Editor.Utils
{
    public class Common
    {
        public static bool ByteArraysEqual(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null && arr2 == null) return true;
            if (arr1 == null && arr2 != null) return false;
            if (arr2 == null && arr1 != null) return false;
            if (arr1.Length != arr2.Length) return false;
            if (arr1.GetHashCode() == arr2.GetHashCode()) return true;

            for (int i = 0, len = arr1.Length; i < len; i++)
                if (arr1[i] != arr2[i])
                    return false;
            return true;
        }

        public static void StringToFixedByteArray(string source, ref byte[] dest)
        {
            byte[] bsource = Encoding.ASCII.GetBytes(source);
            Array.Resize(ref bsource, dest.Length);
            dest = bsource;
        }

        public static byte[] StringToByteArray(string text)
        {
            string hex = text.Replace(" ", "");
            int num = hex.Length;

            if ((num / 2) < 3)
                return null;

            byte[] bytes = new byte[num / 2];
            for (int i = 0; i < num; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return bytes;
        }

        public static string ByteToHex(byte[] buffer)
        {
            return ByteToHex(buffer, buffer.Length);
        }

        public static string ByteToHex(byte[] buffer, int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
                str = str + buffer[i].ToString("X2") + " ";
            return str;
        }

        public static string ByteToText(byte[] buffer)
        {
            return ByteToText(buffer, 0, buffer.Length);
        }

        public static string ByteToText(byte[] buffer, int length)
        {
            return ByteToText(buffer, 0, length);
        }

        public static string ByteToText(byte[] buffer, int index, int length)
        {
            char[] chArray = Encoding.UTF7.GetChars(buffer, index, length);
            string str = "";
            for (int i = 0; i < chArray.Length; i++)
                str = str + chArray[i].ToString();
            return str;
        }

        public static string CharToText(char[] buffer, int index, int length)
        {
            string str = "";
            for (int i = 0; i < buffer.Length; i++)
                str = str + buffer[i].ToString();
            return str;
        }
    }
}
