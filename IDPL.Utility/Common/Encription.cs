using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utility.Common
{
    public class Encription
    {
        private static IConfiguration Configuration;


        private RijndaelManaged rijManaged = new RijndaelManaged();
        private int iterations;
        private byte[] Salt;

        public Encription()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();

            string VectorValue = Configuration.GetValue<string>("AppEncryption:AESUserVector");
            string SaltValue = Configuration.GetValue<string>("AppEncryption:AESUserSalt");
            string strKey = Configuration.GetValue<string>("AppEncryption:AESUserEncrryptKey");
            rijManaged.BlockSize = 128;
            rijManaged.KeySize = 128;
            rijManaged.IV = HexStringToByteArray(VectorValue);
            rijManaged.Padding = PaddingMode.PKCS7;
            rijManaged.Mode = CipherMode.CBC;
            iterations = 1000;
            Salt = System.Text.Encoding.UTF8.GetBytes(SaltValue);
            rijManaged.Key = GenerateKey(strKey);
            //  rijManaged.Key = Encoding.UTF8.GetBytes(strpassword);
        }

        public string Encrypt(string strPassword)
        {
            byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPassword);
            ICryptoTransform transform = rijManaged.CreateEncryptor();
            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            ICryptoTransform transform = rijManaged.CreateDecryptor();
            byte[] cipherText = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return System.Text.Encoding.UTF8.GetString(cipherText);
        }

        public static byte[] HexStringToByteArray(string strHex)
        {
            dynamic r = new byte[strHex.Length / 2];
            for (int i = 0; i <= strHex.Length - 1; i += 2)
            {
                r[i / 2] = Convert.ToByte(Convert.ToInt32(strHex.Substring(i, 2), 16));
            }
            return r;
        }

        private byte[] GenerateKey(string strPassword)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(strPassword, Salt, iterations);
            return rfc2898.GetBytes(128 / 8);
        }

        public static string GetsixUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }


        // added by jay
        public string Convert_StringvalueToHexvalue(string stringvalue, System.Text.Encoding encoding)
        {
            try
            {
                stringvalue = ShikshaConstants.DeepLinkEncodePrefix.ToString() + stringvalue;

                Byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(stringvalue.ToString());
                //Byte[] stringBytes = encoding.GetBytes(stringvalue);
                StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
                foreach (byte b in stringBytes)
                {
                    sbBytes.AppendFormat("{0:X2}", b);
                }
                return sbBytes.ToString();
            }
            catch
            {
                return "0000";
            }
        }
        public string Convert_HexvalueToStringvalue(string hexvalue, System.Text.Encoding encoding)
        {
            int CharsLength = hexvalue.Length;
            byte[] bytesarray = new byte[CharsLength / 2];
            for (int i = 0; i < CharsLength; i += 2)
            {
                bytesarray[i / 2] = Convert.ToByte(hexvalue.Substring(i, 2), 16);
            }

            var base64EncodedBytes = bytesarray;
            string str = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            str = str.Replace(ShikshaConstants.DeepLinkEncodePrefix.ToString(), "");
            return str;

        }
    }
}
