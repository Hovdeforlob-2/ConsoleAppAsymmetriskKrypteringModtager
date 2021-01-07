using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAsymmetriskKrypteringModtager
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RSADecrypt();

            //const string original = "Text to encrypt";
            //const string publicKeyPath = @"C:\Users\Maius\Desktop\test\publickey.xml";
            const string privateKeyPath = @"C:\Users\Maius\Desktop\test\privatekey.xml";

            Console.WriteLine("encryption:");
            string en = "y7UIOSeVPMpTKrt5zGeno7EyOuLHtCBhL8AYOiulslCVEm8shmwzG6DklcfO/QxYuVbun1aylxnSMPpO8d2gA2ljPGau+NNUNfHcOihDvoW3dHhF8NVQpJle9ceFfJiJ6fcur6dTi4l5broaZQMd0qNBQhqmjMd8yY9QstE8usWr2vKTtMJ7QQRgwm8hZnbOLJJxecvbMPAimrSRnHa5po4WvExvQku/DpTTgCaxEsnFE9LQcsCp/I3zAlDiu+lH6c/yvm9/WSXSLhgZsawbsvsyjQqTKmX3yvhbrzns7SKc2glVyQpLsWtoRR7P494qwBw1C1jTOTPyS0np8h/toQ==";


            //rsa.AssignNewKey(publicKeyPath, privateKeyPath);
            //var encrypted = rsa.EncryptData(publicKeyPath, Encoding.UTF8.GetBytes(en));
            var decrypted = rsa.DecryptData(privateKeyPath, Encoding.UTF8.GetBytes(en));

            Console.WriteLine("Xml Based Key");
            //Console.WriteLine();
            ////Console.WriteLine("   Original Text = " + original);
            //Console.WriteLine();
            //Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encrypted));
            //Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decrypted));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
