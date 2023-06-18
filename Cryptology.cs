using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace takvim2
{
     class Cryptology
    {
        public static string Encyrption (string text, string key)
        {
            char[] x = text.ToCharArray();
            string encyrptedText = null;

            foreach (char item in x)
            {
                encyrptedText += Convert.ToChar(item+key);
            }
            return encyrptedText;
        }

        public static string Decyrption(string text , int key)
        {
            char[] x = text.ToCharArray();
            string decyrptedText = null;
            foreach (char item in x)
            {
                decyrptedText += Convert.ToChar(item - key);
            }
            return decyrptedText;
        }

    }
}
