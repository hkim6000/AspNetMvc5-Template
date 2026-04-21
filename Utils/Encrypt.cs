using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AspNetMvc5.Utils
{
    public class Encrypt
    {
        private TripleDES TripleDes = TripleDES.Create();

        public Encrypt(string key)
        {
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);
        }

        private byte[] TruncateHash(string key, int length)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] keyBytes = Encoding.Unicode.GetBytes(key);
                byte[] hash = sha1.ComputeHash(keyBytes);

                Array.Resize(ref hash, length);
                return hash;
            }
        }

        public string EncryptData(string plaintext)
        {
            string rtnValue = string.Empty;

            try
            {
                byte[] plaintextBytes = Encoding.Unicode.GetBytes(plaintext);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = TripleDes.CreateEncryptor())
                    using (CryptoStream encStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        encStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                        encStream.FlushFinalBlock();
                    }
                    rtnValue = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                rtnValue = ex.Message;
            }

            return rtnValue;
        }

        public string DecryptData(string encryptedtext)
        {
            string rtnValue = string.Empty;

            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedtext);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (ICryptoTransform decryptor = TripleDes.CreateDecryptor())
                    using (CryptoStream decStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        decStream.FlushFinalBlock();
                    }
                    rtnValue = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            catch
            {
                rtnValue = string.Empty;
            }

            return rtnValue;
        }
    }
}