using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AES
{
    /// <summary>
    /// A demo analogue of Message Event Receiver/Suscriber model, it'll be updated in the future
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Returns true, if passed email passes the validation, false - otherwise
        /// </summary>
        /// <param name="email">A string containing an email of user, that needs to be validated</param>
        /// <returns></returns>
        public static bool EmailValidation(string email)
        {
            bool isValid = false;
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                isValid = true;

            return isValid;
        }
        /// <summary>
        /// An example of custom email validation using Regex
        /// </summary>
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
