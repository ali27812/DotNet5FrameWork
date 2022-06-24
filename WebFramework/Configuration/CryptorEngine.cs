using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace WebFramework.Configuration
{
    public static class CryptorEngine
    {
        public static string Encrypt(string strText, string publicKey)
        {
            var dataBytes = Encoding.UTF8.GetBytes(strText);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.FromXmlStringExtension(publicKey);
                    var encryptedData = rsa.Encrypt(dataBytes, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decrypt(string strText, string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    var base64Encrypted = strText;
                    rsa.FromXmlStringExtension(privateKey);
                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string DecryptWithKey(string privateKey, string cipher)
        {
            using (var cryptoServiceProvider = new RSACryptoServiceProvider(2048))
            {
                cryptoServiceProvider.PersistKeyInCsp = false;
                cryptoServiceProvider.FromXmlStringExtension(privateKey);
                return Encoding.ASCII.GetString(cryptoServiceProvider.Decrypt(Convert.FromBase64String(cipher), false));
            }
        }

        public static string EncryptWithKey(string publicKey, string plain)
        {
            using (var cryptoServiceProvider = new RSACryptoServiceProvider(2048))
            {
                cryptoServiceProvider.PersistKeyInCsp = false;
                cryptoServiceProvider.FromXmlStringExtension(publicKey);
                return Convert.ToBase64String(cryptoServiceProvider.Encrypt(Encoding.ASCII.GetBytes(plain), false));
            }
        }

        public static string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlStringExtension(xmlString);
            var keySize = dwKeySize / 8;
            var bytes = Encoding.UTF8.GetBytes(inputString);
            // The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
            // int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
            var maxLength = keySize - 42;
            var dataLength = bytes.Length;
            var iterations = dataLength / maxLength;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i <= iterations; i++)
            {
                var tempBytes = new byte[dataLength - maxLength * i > maxLength ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                var encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }

            return stringBuilder.ToString();
        }

        public static string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlStringExtension(xmlString);
            var base64BlockSize = dwKeySize / 8 % 3 != 0 ? dwKeySize / 8 / 3 * 4 + 4 : dwKeySize / 8 / 3 * 4;
            var iterations = inputString.Length / base64BlockSize;
            var arrayList = new ArrayList();
            for (var i = 0; i < iterations; i++)
            {
                var encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }

            return Encoding.UTF8.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
        }

        public static string SignData(string message, string privateKey)
        {
            //// The array to store the signed message in bytes
            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                //// Write the message to a byte array using UTF8 as the encoding.
                var encoder = new UTF8Encoding();
                var originalData = encoder.GetBytes(message);
                try
                {
                    rsa.FromXmlStringExtension(privateKey);

                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

            return Convert.ToBase64String(signedBytes);
        }

        public static bool VerifyData(string originalMessage, string signedMessage, string publicKey)
        {
            bool success;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                var bytesToVerify = encoder.GetBytes(originalMessage);
                var signedBytes = Convert.FromBase64String(signedMessage);
                try
                {
                    rsa.FromXmlStringExtension(publicKey);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException)
                {
                    return false;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

            return success;
        }
    }
}
