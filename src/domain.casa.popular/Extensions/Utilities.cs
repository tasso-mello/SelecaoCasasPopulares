namespace domain.casa.popular.Extensions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Security.Cryptography;

    public static class Utilities
    {
        public static Guid? _userId;
        public static int[]? TakeSubCategoriesFromQueryString(this string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
                return null;

            var arrayInt = queryString.Split(',');
            return arrayInt.Select(i => Convert.ToInt32(i)).ToArray();
        }

        public static string TakeRefererUrl(this string referer, string scheme, string host)
            => referer.Replace($"{scheme}://{host}", string.Empty);

        public static string Encode(this string toEncrypt)
        {
            using (var aes = new AesManaged())
                return Convert.ToBase64String(Encrypt(toEncrypt, new byte[32], new byte[16]));
        }

        public static string Decode(this string toDecrypt)
        {
            using (var aes = new AesManaged())
                return Decrypt(Convert.FromBase64String(toDecrypt), new byte[32], new byte[16]);
        }

        public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (var aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            var stringResult = string.Empty;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            stringResult = reader.ReadToEnd();
                    }
                }
            }

            return stringResult;
        }

        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        public static JObject ToJson(this string json)
            => JObject.Parse(json);

        public static string GetErrorMessage(this JObject json)
            => json["error"]["message"].ToString();
    }
}
