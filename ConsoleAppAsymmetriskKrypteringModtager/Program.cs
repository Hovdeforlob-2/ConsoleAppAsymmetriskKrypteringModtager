using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAsymmetriskKrypteringModtager
{
    class Program
    {
        static void Main(string[] args)
        {
            RSADecrypt rsa = new RSADecrypt();
            Gui gui = new Gui();
            XmlReader xmlReader = new XmlReader();

            const string publicKeyPath = @"C:\Users\Maius\Desktop\test\publickey.xml";
            const string privateKeyPath = @"C:\Users\Maius\Desktop\test\privatekey.xml";

            string[] choicesForTheUser = { "Create new key pair", "Decrypt message", "Private Key data", "Public key data" };
            gui.SetMenuHeading();
            gui.SetMenuBody(choicesForTheUser);

            int usrNo = 0;
            try
            {
                Console.WriteLine("pleace enter a number:");
                usrNo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered a non valid number");
                Console.ResetColor();
            }
            switch (usrNo)
            {
                case 1:
                    rsa.AssignNewKey(publicKeyPath, privateKeyPath);
                    break;
                case 2:
                    /*byte[] encryptedMessage = Convert.FromBase64String(Console.ReadLine()); // jeg ville have lavet som brugerne selv kunne insætte en encrypted Message 
                    med console vil ikke lade mig insætte så maget */

                    Console.WriteLine("encryption:");
                    byte[] encryptedMessage = Convert.FromBase64String("MFRge6mhUTQK8K2kSCSmiLjqPJb4g7K7po1nLQTi29Lc02C9CT3m/Z+bF97wah0eZPo7QFfIGTNG5SS9wEq+vJC5sd/yVC8opa9TI8sC+S1qASgzXjmnAzSoP7n/GyIMDOKA2oVE67pRHHSWEPgEpVmP4ea4FXQB26XZWAJ4LvInHVYtOYcqzFtPBM/KFIqyQBIzr5Qjurg1l9J6pGT+KdIKnM4F9exCyTWZvqTOP5UB7WtqFyWulG69FJrH8y+Zj4wJHpXgPdEwONrZVWuoGehDyaFVPOmx2vUpsUKuZjD3IKGFxTySQz7k+rRit2JWK35GrRsLx0yPOhNDO/X5wg==");
                    byte[] decrypted = rsa.DecryptData(privateKeyPath, encryptedMessage);
                    Console.WriteLine("Decrypted Text = " + Encoding.Default.GetString(decrypted));
                    break;
                case 3:
                    Console.WriteLine("Privat key Data:");
                    xmlReader.GetDataFromPrivateKeyXmlFile(privateKeyPath);
                    break;
                case 4:
                    Console.WriteLine("Public key Data:");
                    xmlReader.GetDataFromPublicKeyXmlFile(publicKeyPath);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you have entered a number there is out of range");
                    Console.ResetColor();
                    break;
            }
            Console.ReadKey();
        }
    }
}
