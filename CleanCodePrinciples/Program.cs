using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodePrinciples
{
    public enum UserType
    {
        Free,
        Member
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            #region Boolean Comparisons and Expressions 
            bool isValid = false;
            //Dirty Code
            if (isValid == true)
            {

            }
            //this use is more convenient for simplicity and readability
            if (isValid)
            {

            }

            /*-------------------------------------------------------------*/

            int note = 0;
            bool isPassed;
            //Dirty Code
            if (note > 50)
            {
                isPassed = true;
            }
            else
            {
                isPassed = false;
            }
            //reduced signal to noise ratio is preferred for legibility
            bool isPassed2 = note > 50;

            #endregion

            #region Positive Conditional
            bool hasCode = true;
            bool hasNotCode = false;
            //Dirty Code
            if (!hasNotCode) { }

            //Be Positive!
            if (hasCode) { }

            #endregion

            #region Ternary If
            int x = 10, y = 100;
            string result;
            //Dirty Code
            if (x > y)
            {
                result = "x is greater than y";
            }
            else if (x < y)
            {
                result = "x is less than y";
            }
            else
            {
                result = "x is equal to y";
            }

            //Ternary If
            string result2 = x > y ? "x is greater than y"
                                    : x < y ? "x is less than y"
                                        : "x is equal to y";

            #endregion

            #region Definitions
            //Dirty Code
            int value = 10;
            //
            //a lot of code
            //
            if (value > 5) //what is value?
            {

            }

            //Clean Code
            int value2 = 10;
            if (value2 > 5)
            {

            }
            #endregion

            #region Complex Conditions
            string member = "Gold";
            DateTime membershipDate = new DateTime(2016, 12, 25);

            //Dirty Code
            if ((DateTime.Now.Year - membershipDate.Year) >= 5 && member == "Gold")
            {

            }

            //Clean Code
            bool isProvide = (DateTime.Now.Year - membershipDate.Year) >= 5 && member == "Gold";
            if (isProvide)
            {

            }
            #endregion

            #region Linq
            List<User> users = new List<User>();
            List<User> members = new List<User>();

            foreach (var user in users)
            {
                if (user.TypeOfUser == UserType.Member)
                {
                    members.Add(user);
                }
            }

            //Linq
            members = users.Where(u => u.TypeOfUser == UserType.Member).ToList();
            #endregion
        }

        #region Strongly Type
        //Dirty Code
        public void CompareString()
        {
            User user = new User();
            if (user.UserType == "Member")
            {

            }
        }
        //Strongly Type
        public void CompareString2()
        {
            User user = new User();
            if (user.TypeOfUser == UserType.Member)
            {

            }
        }

        #endregion
    }
    class User
    {
        public UserType TypeOfUser { get; set; }
        public string UserType { get; set; }

        #region Positive Conditional 2
        List<int> userId = new List<int> { 1, 2 };
        //Dirty Code
        public bool IsEmpty()
        {
            return !userId.Any();
        }

        //Be Positive!
        public bool IsEmpty2()
        {
            return userId.Count == 0;
        }
        #endregion
    }

    class SampleClass
    {
        #region Variables
        //Dirty Code
        public bool Validate(string password)
        {
            int minPasswordLenght = 5;
            int maxPasswordLenght = 25;

            if (password.Length < minPasswordLenght)
                return false;
            if (password.Length > maxPasswordLenght)
                return false;

            return true;
        }

        //Clean Code
        public bool Validate2(string password)
        {
            int minPasswordLenght = 5;
            if (password.Length < minPasswordLenght)
                return false;

            int maxPasswordLenght = 25;
            if (password.Length > maxPasswordLenght)
                return false;

            return true;
        }

        #endregion

        #region Parameters
        //Dirty Code
        public void SaveUser(string userName,
                             string password,
                             string email,
                             bool sendEmail,
                             bool sendBill,
                             bool printReport)
        {

        }

        //Clean Code
        public void SaveUser2(string userName, string password, string email)
        {

        }
        public void sendEmail()
        {

        }
        public void sendBill()
        {

        }
        public void printReport()
        {

        }

        #endregion

        #region Exctract Method
        //Dirty Code
        public void Sample()
        {
            if (true)
            {
                if (true)
                {
                    do
                    {
                        // 
                    } while (true);
                }
            }
        }

        //Clean Code
        public void Sample2()
        {
            if (true)
            {
                if (true)
                {
                    DoSomething();
                }
            }
        }
        private void DoSomething()
        {
            do
            {
                //
            } while (true);
        }

        #endregion

        #region Fail Fast
        //Dirty Code
        public void Login(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                //
                if (!string.IsNullOrWhiteSpace(password))
                {
                    //Login
                }
                else
                {
                    throw new ArgumentNullException(); //Exception
                }
            }
            else
            {
                throw new ArgumentNullException(); //Exception
            }
        }

        //Clean Code
        public void Login2(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            // Login
        }

        #endregion

        #region Return Early
        //Dirty Code
        private bool ValidUserName(string userName)
        {
            int minUserNameLenght = 5;
            int maxUserNameLenght = 20;
            bool isValid = false;

            if (userName.Length >= minUserNameLenght)
            {
                if (userName.Length <= maxUserNameLenght)
                {
                    bool isAlphaNumeric = userName.All(Char.IsLetterOrDigit);
                    if (isAlphaNumeric)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        //Clean Code
        private bool ValidUserName2(string userName)
        {
            int minUserNameLenght = 6;
            if (userName.Length < minUserNameLenght)
                return false;
            int maxUserNameLenght = 20;
            if (userName.Length > maxUserNameLenght)
                return false;
            bool isAlphaNumeric = userName.All(Char.IsLetterOrDigit);
            if (!isAlphaNumeric)
                return false;

            return true;
        }
        #endregion
    }
}
