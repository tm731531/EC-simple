using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Utils
{
    public class GenUtils
    {
        private static readonly char[] chars =
               "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public static string GenerateKey(int length)
        {
            var sb = new StringBuilder();
            var rng = new Random();

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rng.Next(chars.Length)]);
            }

            return sb.ToString();
        }

        public static string EncodeSensetiveDataKey(string targetStr)
        {
            //int hash = str1.GetHashCode();
            //int start = Math.Abs(hash % str2.Length);
            //string selected = TakeCharsCircular(str2, start,32);

            string encoded = targetStr;
            for (int i = 0; i < 3; i++)
            {
                encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(encoded));
            }

            return encoded;
        }

        // 解碼
        public static string DecodeSensetiveDataKey(string encoded, string key)
        {
            string decoded = encoded;
            for (int i = 0; i < 3; i++)
            {
                byte[] bytes = Convert.FromBase64String(decoded);
                decoded = Encoding.UTF8.GetString(bytes);
            }
            int hash = key.GetHashCode();
            int start = Math.Abs(hash % decoded.Length);
            string selected = TakeCharsCircular(decoded, start, 32);
            return selected;
        }

        // 補環繞字元
        private static string TakeCharsCircular(string input, int start,int size)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(input[(start + i) % input.Length]);
            }
            return sb.ToString();
        }
    }
}
