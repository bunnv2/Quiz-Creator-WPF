using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Creator_WPF
{
    internal class Encryption
    {
        public static string Encrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                output += (char)(c + 1);
            }
            return output;
        }

        public static string Decrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                output += (char)(c - 1);
            }
            return output;
        }   
    }
}
