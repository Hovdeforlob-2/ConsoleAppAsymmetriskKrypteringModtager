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
            RSADecrypt rsa = new RSADecrypt();
            Gui gui = new Gui();

            //const string original = "Text to encrypt";
            const string publicKeyPath = @"C:\Users\Maius\Desktop\test\publickey.xml";
            const string privateKeyPath = @"C:\Users\Maius\Desktop\test\privatekey.xml";

            string[] choicesForTheUser = { "Create new key pair", "Decrypt message" };
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
                    Console.WriteLine("encryption:");
                    string en = "y7UIOSeVPMpTKrt5zGeno7EyOuLHtCBhL8AYOiulslCVEm8shmwzG6DklcfO/QxYuVbun1aylxnSMPpO8d2gA2ljPGau+NNUNfHcOihDvoW3dHhF8NVQpJle9ceFfJiJ6fcur6dTi4l5broaZQMd0qNBQhqmjMd8yY9QstE8usWr2vKTtMJ7QQRgwm8hZnbOLJJxecvbMPAimrSRnHa5po4WvExvQku/DpTTgCaxEsnFE9LQcsCp/I3zAlDiu+lH6c/yvm9/WSXSLhgZsawbsvsyjQqTKmX3yvhbrzns7SKc2glVyQpLsWtoRR7P494qwBw1C1jTOTPyS0np8h/toQ==";

                    var decrypted = rsa.DecryptData(privateKeyPath, Encoding.UTF8.GetBytes(en));
                    Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decrypted));
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
