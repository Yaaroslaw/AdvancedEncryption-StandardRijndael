using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AES
{
    public class EmailService
    {
        public static bool EmailValidation(string email)
        {
            bool isValid = false;
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                isValid = true;

            return isValid;
        }
        public static void EmailValidationExample()
        {
            var emails = new string[]{
                "ye@gmail.com",
                "@yegmail.com",
                "やまだye@gmail.comやまだ"
            };


            foreach (var email in emails)
            {

                if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    Console.WriteLine("fail[2]");

                else
                    Console.WriteLine("succes[2]");
            }
        }
    }
}
