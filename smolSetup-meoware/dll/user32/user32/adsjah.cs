using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace user32
{
    public class adsjah
    {
        public static byte[] Encrypt(byte[] data, byte[] key, byte[] IV)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(data, 0, data.Length);
                        csEncrypt.FlushFinalBlock();
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public static string ConvertStr(byte[] data)
        {
            return System.Convert.ToBase64String(data);
        }

        public static byte[] RevertStr(string text)
        {
            return System.Convert.FromBase64String(text);
        }

        static Random random = new Random();
        public static string GenIV(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}