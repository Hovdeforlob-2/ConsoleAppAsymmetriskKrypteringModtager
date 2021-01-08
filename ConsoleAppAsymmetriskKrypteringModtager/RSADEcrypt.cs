using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleAppAsymmetriskKrypteringModtager
{
    class RSADecrypt
    {
        /// <summary>
        /// laver en telfældig privat key og public key
        /// og sender dem til to forskille filer
        /// </summary>
        /// <param name="publicKeyPath"></param>
        /// <param name="privateKeyPath"></param>
        public void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);
                var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyfolder))
                {
                    Directory.CreateDirectory(publicKeyfolder);
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    Directory.CreateDirectory(privateKeyfolder);
                }

                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }

        /// <summary>
        /// laver en decryptene af en encrytet besked og dens engen private key 
        /// så man får en plan text ingen
        /// </summary>
        /// <param name="privateKeyPath"></param>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        public byte[] DecryptData(string privateKeyPath, byte[] dataToEncrypt)
        {
            byte[] plain;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));
                plain = rsa.Decrypt(dataToEncrypt, false);
            }

            return plain;
        }
    }
}
