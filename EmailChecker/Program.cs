using System;

namespace EmailChecker
{
    class Program
    {
        public static bool IsEmailAdress(string emailAdress)
        {
            int iAt = emailAdress.IndexOf('@');
            int iDot = emailAdress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        }


        static void TestIsEmailAdress(string emailAdress, bool expected)
        {
            bool result = IsEmailAdress(emailAdress);

             if (result == expected)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("NO SUCCESS");
            }
        }


        static void Main(string[] args)
        {   

            TestIsEmailAdress("irgendwas@web.de", true);
            
            TestIsEmailAdress("@web.de", false);

            TestIsEmailAdress("test@web.de.be", true);

            TestIsEmailAdress("a@.", false);
        }
    }
}
