using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BusDep.Common
{
    public static class Encrypt
    {
        #region atributos
        const string SEncryptionKey = "BusDeparg";
        #endregion

        #region metodos
        /// <summary>
        /// Desencripta un String.
        /// </summary>
        /// <param name="stringToDecrypt">String a desencriptar</param>
        /// <param name="encryptionKey">Clave mayor o igual de 8 caracteres para desencriptar.</param>
        /// <returns></returns>
        public static String DecryptFromString64(String stringToDecrypt, String encryptionKey)
        {
            if (String.IsNullOrEmpty(encryptionKey) || encryptionKey.Length < 8)
                throw new Exception("La clave para desencriptar debe tener 8 o más caracteres");
            // Use DES CryptoService with Private key pair
            byte[] iv = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputbyteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, iv), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        /// <summary>
        /// Desencripta un String.
        /// </summary>
        /// <param name="stringToDecrypt">String a desencriptar</param>
        public static String DecryptFromString64(String stringToDecrypt)
        {
            string encryptionKey = SEncryptionKey;

            if (String.IsNullOrEmpty(encryptionKey) || encryptionKey.Length < 8)
                throw new Exception("La clave para desencriptar debe tener 8 o más caracteres");
            // Use DES CryptoService with Private key pair
            byte[] iv = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputbyteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, iv), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        /// <summary>
        /// Encripta un String.
        /// </summary>
        /// <param name="stringToEncrypt">String a encriptar</param>
        /// <returns></returns>
        public static string EncryptToBase64String(string stringToEncrypt)
        {
            string encryptionKey = SEncryptionKey;
            if (String.IsNullOrEmpty(encryptionKey) || encryptionKey.Length < 8)
                throw new Exception("La clave para encriptar debe tener 8 o más caracteres");
            // Use DES CryptoService with Private key pair
            byte[] iv = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputbyteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();

            string s = Convert.ToBase64String(ms.ToArray());

            if (s.IndexOf(";") >= 0)
                throw new Exception("Invalid string");
            return s;
        }
        /// <summary>
        /// Encripta un String.
        /// </summary>
        /// <param name="stringToEncrypt">String a encriptar</param>
        /// <param name="encryptionKey">Clave mayor o igual de 8 caracteres para encriptar.</param>
        /// <returns></returns>
        public static String EncryptToBase64String(String stringToEncrypt, String encryptionKey)
        {
            if (String.IsNullOrEmpty(encryptionKey) || encryptionKey.Length < 8)
                throw new Exception("La clave para encriptar debe tener 8 o más caracteres");

            // Use DES CryptoService with Private key pair
            byte[] iv = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputbyteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        #endregion
    }
}