using System;
using System.Text.RegularExpressions;

namespace Regexp
{
    class Program
    {
        static void Main(string[] args)
        {
            Build(); //Kicks off the program.
        }

        public static void Build()
        {
            //Build Regex Requirements.
            string nameReg = @"^[A-Z]{1}[a-zA-Z\s]{0,29}$"; 
            //Format: Xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            string emailReg = @"^[A-Za-z0-9]{5,30}\@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}$"; 
            //Format: XXXXX-XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX@XXXXX-XXXXXXXXXX.XX-XXX

            string phoneNumberReg = @"[0-9]{3}\-[0-9]{3}\-[0-9]{4}"; 
            //Format: XXX-XXX-XXXX

            string phone2NumberReg = @"^\([0-9]{3}\)-[0-9]{3}-[0-9]{4}"; 
            //Format: (XXX)-XXX-XXXX

            string phone3NumberReg = @"[0-9]{3}\.[0-9]{3}\.[0-9]{4}"; 
            //Format: XXX.XXX.XXXX

            string dateReg = @"\d\d\/\d\d\/\d\d\d\d";
            //Format: XX/XX/XXXX

            bool validate = true;
            while (validate)
            { 
                //Run Regex Methods.
                GetValidName(nameReg);
                GetValidEmail(emailReg);
                GetValidPhone(phoneNumberReg, phone2NumberReg, phone3NumberReg);
                GetValidDate(dateReg);
                GetMoreValidation(out validate);
            }

        }

        public static void GetValidName(string req) 
        //Method for testing user input against Regex requirements for name.
        {
            Regex reg = new Regex(req);
            Console.Clear();
            Console.WriteLine("Please tell us your name.");
            Console.WriteLine("MUST begin with a capital letter!");
            Console.WriteLine("A maximum of 30 characters, only alphabetical characters please.");
            GetSpace();
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine($"Checking name against valid format: {matched}");
            GetSpace();
        }

        public static void GetValidEmail(string req) 
        //Method for testing user input against Regex requirements for email.
        {
            Regex reg = new Regex(req);
            GetSpace();
            Console.WriteLine("Please enter your desired email.");
            Console.WriteLine("Char Rules:(5-30)@(5-10).(2-3), no special characters please.");
            GetSpace();
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine($"Checking name against valid format: {matched}");
        }

        public static void GetValidPhone(string req, string req2, string req3) 
        //Method for testing user input against Regex requirements for phone.
        {
            Regex reg = new Regex(req);
            GetSpace();
            Console.WriteLine("Please enter your desired phone number.");
            Console.WriteLine("Format rules: XXX-XXX-XXXX, XXX.XXX.XXXX, (XXX)-XXX-XXXX");
            GetSpace();
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);
            if (matched == true)
            {
                Console.WriteLine($"Checking name against valid format: {matched}");
                return;
            }
            else
            {
                ContinuePhone1(req2, req3, mystring);
            }   
        }
        public static void ContinuePhone1(string req2, string req3, string mystring) 
        //Method for phone to pass to, second format accepted.
        {
            Regex reg = new Regex(req2);
            bool matched = reg.IsMatch(mystring);
            if (matched == true)
            {
                Console.WriteLine($"Checking name against valid format: {matched}");
                return;
            }
            else
            {
                ContinuePhone2(req3, mystring);
            }
        }

        public static void ContinuePhone2(string req3, string mystring) 
        //Method for phone to pass to, third format accepted.
        {
            Regex reg = new Regex(req3);
            bool matched = reg.IsMatch(mystring);
            Console.WriteLine($"Checking name against valid format: {matched}");
            return;
        }

        public static void GetValidDate(string req) 
        //Method for date entry to pass through, limiting day to 1-12 and month to 1-31.
        {
            Regex reg = new Regex(req);
            GetSpace();
            int monthNumber = GetValidMonth("Please enter your month. (1-12)");
            GetValidDateFormat(monthNumber,out string monthNum);

            GetSpace();
            int dayNumber = GetValidDay("Please enter your day number. (1-31)");
            GetValidDateFormat(dayNumber,out string dayNum);

            GetSpace();
            int yearNumber = GetValidYear("Please enter your year number. (1000-9999)");
            string yearNum = yearNumber.ToString();

            GetSpace();
            string mystring = (monthNum + "/" + dayNum + "/" + yearNum);
            bool matched = reg.IsMatch(mystring);
            GetSpace();
            Console.WriteLine(mystring);
            Console.WriteLine($"Checking against valid format: {matched}");
        }

        public static int GetValidMonth(string prompt) 
        //Month number validation 1-12 & number.
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);
            while (!isValid || number <= 0 || number > 12)
            {
                GetSpace();
                Console.WriteLine("Please enter a valid number between 1 & 12.");
                GetSpace();
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int GetValidDay(string prompt) 
        //Day number validation 1-31 & number.
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);

            while (!isValid || number <= 0 || number > 31)
            {
                GetSpace();
                Console.WriteLine("Please enter a valid number between 1 & 31.");
                GetSpace();
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static int GetValidYear(string prompt) 
        //Year number validation 1000-9999 & number.
        {
            Console.WriteLine(prompt);
            bool isValid = int.TryParse(Console.ReadLine(), out int number);

            while (!isValid || number <= 1000 || number > 9999)
            {
                GetSpace();
                Console.WriteLine("Please enter a valid number between 1000 & 9999.");
                GetSpace();
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        public static bool GetValidDateFormat(int num1, out string s1) 
        //Corrects entry from single digit to double digit in the event of a 1-9.
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
        public static void GetSpace()
        //Outerspaaaaaaaaaaace! JK. Shortcut method for spacing.
        {
            Console.WriteLine("");
        }

        public static bool GetMoreValidation(out bool morePlease)
        {
            GetSpace();
            Console.WriteLine("Would you like to run the validation set again? (Y/N)");

            string input = Console.ReadLine();
            string lowerInput = input.ToLower();
            if(lowerInput == "yes" || lowerInput == "y")
            {
                morePlease = true;
                return true;
            }
            else if(lowerInput == "no" || lowerInput == "n")
            {
                morePlease = false;
                return false;
            }
            else
            {
                GetMoreValidation(out morePlease);
                return false;
            }
        }
    }
}