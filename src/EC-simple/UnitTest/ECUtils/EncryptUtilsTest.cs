using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.Utils;

namespace UnitTest.ECUtils
{
    internal class EncryptUtilsTest
    {


        private static string key = "12345678901234561234567890123456"; // 16 字元 = 128 bit
        private static string iv = "6543210987654321";  // 16 字元 = 128 bit
        private static string plainText = "Hello AES World!";
        private static string encrypted = "zltcweLrHLFh97mf7NZWI3OojGwpzGXTbWTZgPQldPU=";

        public static void Encrypted()
        {

            string encrypted = EncryptUtils.Encrypt(plainText, key, iv);
            Console.WriteLine($"Encrypted: {encrypted}");
        }

        public static void Decrypt()
        {

            string decrypted = EncryptUtils.Decrypt(encrypted, key, iv);
            Console.WriteLine($"Decrypted: {decrypted}");
        }

        public static void GenerateAESKeyAndIV()
        {

            (string key, string iv) value = EncryptUtils.GenerateAESKeyAndIV();
            Console.WriteLine($"key: {value.key} , iv: {value.iv}");
        }

    }
}
