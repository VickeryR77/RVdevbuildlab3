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
            string emailReg = @".{4,30}[^!@#$%^&*()<>;:'.,/{}~+\-_=|]@.{4,10}[^!@#$%^&*()<>;:'.,/{}~+\-_=|]\..{1,3}[^!@#$%^&*()<>;:'.,/{}~+\-_=|]";
            string phoneNumberReg = @"[0-9]{2,3}\-[0-9]{2,3}\-[0-9]{3,4}"; //XXX-XXX-XXXX
            string phone2NumberReg = @"^\([0-9]{3}\)-[0-9]{3}-[0-9]{4}"; //(XXX)-XXX-XXXX
            string phone3NumberReg = @"[0-9]{3}\.[0-9]{3}\.[0-9]{4}"; //XXX.XXX.XXXX
            string dateReg = @"\d\d\/\d\d\/\d\d\d\d"; //XX/XX/XXXX

            //Idea for date problem
            //3 separate variables determined by Console.ReadLine(); with max criteria.
            //1+2+3.ToString
            //Regex evaluate the string.

            //Look up HTML code to put into this.


            //Run Regex Methods.
            GetValidName(nameReg);
            GetValidEmail(emailReg);
            GetValidPhone(phoneNumberReg, phone2NumberReg, phone3NumberReg);
            GetValidDate(dateReg);

        }
        public static void GetValidName(string req)
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
            Console.WriteLine("Format rules: XXX-XXX-XXXX");
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
            Console.WriteLine("Please enter your desired date.");
            Console.WriteLine("Format rules: mm/dd/yyyy");
            string mystring = Console.ReadLine();
            bool matched = reg.IsMatch(mystring);

            Console.WriteLine(matched);
        }
    }
}


/*
 * if (matched == true)
            {
                Console.WriteLine(matched);
                return;
            }
            else
            {
                Regex reg2 = new Regex(req2);
bool matched2 = reg.IsMatch(mystring);
                if(matched2 == true)
                {
                    Console.WriteLine(matched2);
                    return;
                }
                else
                {
                    Regex reg3 = new Regex(req3);
bool matched3 = reg.IsMatch(mystring);
Console.WriteLine(matched3);
                    return;
                    
                }
            }
    */