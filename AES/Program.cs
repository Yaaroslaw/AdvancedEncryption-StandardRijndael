using System;
using System.IO;
using System.Security.Cryptography;


namespace AES
{/// <summary>
/// Need to add Event, Handler
/// </summary>
    public class Program
    {      
        public static void Main()
        {           
            var isEmailValid = false;
            Console.WriteLine("Enter your email:");
            while (!isEmailValid){

                isEmailValid = EmailService.EmailValidation(Console.ReadLine());
                if (isEmailValid)
                    break;
                Console.WriteLine("Please, try again:");
            }
            //EmailService.EmailValidationExample();  UNCOMMENT THIS TO SEE HOW VALIDATION WORKS   
            try
            {
                using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
                {
                    using (StreamReader file = new StreamReader("FileToEncrypt.txt")) 
                    using (FileStream byteWriter = new FileStream("EncryptedData.txt", FileMode.Append, FileAccess.Write)) 
                    using (StreamWriter resultFile = new StreamWriter("DecryptedData.txt"))
                    {
                        string line = "";
                        while ((line = file.ReadLine()) != null)
                        {
                            var words = line.Split();
                            // Writes a block of bytes to this stream using data from
                            // a byte array.
                            byte[] encrypted = Encryption.EncryptStringToBytes_Aes(words[1], myAes.Key, myAes.IV);
                            byteWriter.Write(encrypted, 0, encrypted.Length);
                            resultFile.Write(Convert.ToBase64String(encrypted));
                            // Decrypt the bytes to a string.
                            string roundtrip = Encryption.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                            resultFile.WriteLine(words[0] + encrypted);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }        
    }
}
