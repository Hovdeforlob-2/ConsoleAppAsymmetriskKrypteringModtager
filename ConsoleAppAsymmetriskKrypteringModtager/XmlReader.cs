using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAppAsymmetriskKrypteringModtager
{
    class XmlReader
    {
        public void GetDataFromPrivateKeyXmlFile(string privateKeyPath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(privateKeyPath);

            XmlNodeList xnList = xml.SelectNodes("RSAKeyValue");
            foreach (XmlNode xn in xnList)
            {
                string modulus = xn["Modulus"].InnerText;
                string exponent = xn["Exponent"].InnerText;
                string p = xn["P"].InnerText;
                string q = xn["Q"].InnerText;
                string dp = xn["DP"].InnerText;
                string dq = xn["DQ"].InnerText;
                string inverseQ = xn["InverseQ"].InnerText;
                string d = xn["D"].InnerText;

                Gui gui = new Gui();
                gui.PrintKeyData("Modulus", modulus);
                gui.PrintKeyData("Exponent", exponent);
                gui.PrintKeyData("p", p);
                gui.PrintKeyData("Q", q);
                gui.PrintKeyData("DP", dp);
                gui.PrintKeyData("DQ", dq);
                gui.PrintKeyData("InverseQ", inverseQ);
                gui.PrintKeyData("D", d);
            } 
        }

        public void GetDataFromPublicKeyXmlFile(string publicKeyPath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(publicKeyPath);

            XmlNodeList xnList = xml.SelectNodes("RSAKeyValue");
            foreach (XmlNode xn in xnList)
            {
                string modulus = xn["Modulus"].InnerText;
                string exponent = xn["Exponent"].InnerText;

                Gui gui = new Gui();
                gui.PrintKeyData("Modulus", modulus);
                gui.PrintKeyData("Exponent", exponent);
            }
        }
    }
}
