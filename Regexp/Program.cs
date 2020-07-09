using System;
using System.Text.RegularExpressions;

namespace Regexp
{
    class Program
    {
        static void Main(string[] args)
        {

            Build();

        }

        public static void Build()
        {
            //Build Regex Requirements.
            string nameReg = @"^[A-Z][a-z]{0,30}"; 
            //Format: XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            string emailReg = @"[A-Za-z0-9]{5,30}\@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}"; 
            //Format: XXXXX-XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX@XXXXX-XXXXXXXXXX.XX-XXX

            string phoneNumberReg = @"[0-9]{3}\-[0-9]{3}\-[0-9]{4}"; 
            //Format: XXX-XXX-XXXX

            string phone2NumberReg = @"^\([0-9]{3}\)-[0-9]{3}-[0-9]{4}"; 
            //Format: (XXX)-XXX-XXXX

            string phone3NumberReg = @"[0-9]{3}\.[0-9]{3}\.[0-9]{4}"; 
            //Format: XXX.XXX.XXXX

            string dateReg = @"\d\d\/\d\d\/\d\d\d\d"; 
            //Format: XX/XX/XXXX

            //Run Regex Methods.
            GetValidName(nameReg);
            GetValidEmail(emailReg);
            GetValidPhone(phoneNumberReg, phone2NumberReg, phone3NumberReg);
            GetValidDate(dateReg);
        }
        public static void GetValidName(string req) //Method for testing user input against Regex requirements
        {
            Regex reg = new Regex(req);
            Console.WriteLine("Please tell us your name.");
            Console.WriteLine("A maximum of 30 characters, only alphabetical characters please.");
            Console.WriteLine("");
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine(matched);
        }

        public static void GetValidEmail(string req)
        {
            Regex reg = new Regex(req);
            Console.WriteLine("Please enter your desired email.");
            Console.WriteLine("Char Rules:(5-30)@(5-10).(2-3), no special characters please.");
            Console.WriteLine("");
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine(matched);
        }

        public static void GetValidPhone(string req, string req2, string req3)
        {
            Regex reg = new Regex(req);
            Console.WriteLine("Please enter your desired phone number.");
            Console.WriteLine("Format rules: XXX-XXX-XXXX, XXX.XXX.XXXX, (XXX)-XXX-XXXX");
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            if (matched == true)
            {
                Console.WriteLine(matched);
                return;
            }
            else
            {
                ContinuePhone1(req2, req3, mystring);
            }   
        }
        public static void ContinuePhone1(string req2, string req3, string mystring)
        {
            Regex reg = new Regex(req2);
            bool matched = reg.IsMatch(mystring);
            if (matched == true)
            {
                Console.WriteLine(matched);
                return;
            }
            else
            {
                ContinuePhone2(req3, mystring);
            }
        }

        public static void ContinuePhone2(string req3, string mystring)
        {
            Regex reg = new Regex(req3);
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine(matched);
            return;
        }

        public static void GetValidDate(string req)
        {
            Regex reg = new Regex(req); 
            int monthNumber = GetValidMonth("Please enter your month. (1-12)");
            GetValidDateFormat(monthNumber,out string monthNum);

            int dayNumber = GetValidDay("Please enter your day number. (1-31)");
            GetValidDateFormat(dayNumber,out string dayNum);

            int yearNumber = GetValidYear("Please enter your year number. (1000-9999)");
            string yearNum = yearNumber.ToString();

            Console.WriteLine("");
            Console.WriteLine("Checking against valid format: mm / dd / yyyy");
            string mystring = (monthNum+"/"+dayNum+"/"+yearNum);
            Console.WriteLine(mystring);
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine(matched);
        }

        public static int GetValidMonth(string prompt)
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);
            while (!isValid || number <= 0 || number > 12)
            {
                Console.WriteLine("Please enter a valid number between 1 & 12.");
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int GetValidDay(string prompt)
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);

            while (!isValid || number <= 0 || number > 31)
            {
                Console.WriteLine("Please enter a valid number between 1 & 31.");
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int GetValidYear(string prompt)
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);

            while (!isValid || number <= 1000 || number > 9999)
            {
                Console.WriteLine("Please enter a valid number between 1000 & 9999.");
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static bool GetValidDateFormat(int num1, out string s1)
        {
            if (num1 < 10)
            {
                s1 = ("0" + num1.ToString());
                return false;
            }
            else
            {
                s1 = (num1.ToString());
                return true;
            }
        }
    }
}