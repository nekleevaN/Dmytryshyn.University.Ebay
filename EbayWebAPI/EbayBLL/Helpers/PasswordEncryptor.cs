using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayBLL.Helpers
{
    public static class PasswordEncryptor
    {
        const int caesarShift = 3;

        public static string Encrypt(string password)
        {
            string encryptedPassword = "";
            foreach (char c in password)
            {
                char encryptedChar = (char)(c + caesarShift);
                encryptedPassword += encryptedChar;
            }
            return encryptedPassword;
        }

        public static string Decrypt(string password)
        {
            string decryptedPassword = "";
            foreach (char c in password)
            {
                char decryptedChar = (char)(c - caesarShift);
                decryptedPassword += decryptedChar;
            }
            return decryptedPassword;
        }
    }
}
