using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdvancedProgramming
{
    public class CheckInput
    {
        private bool IsValidLength(string input)
        {
            if (input.Length != 1)
                return false;
            return true;
        }

        private bool IsNumber(string input)
        {
            foreach (Char c in input)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsDateTime(string takeDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(takeDate, out tempDate);
        }
        public bool IsValidationSwitch(string input)
        {
            if ((IsValidLength(input) == false) || (IsNumber(input) == false))
                return false;
            return true;
        }
        public int IsNotDuplicate(string ID, string newID)
        {
            if (newID != ID)
            {
                return 0;
            }
            return -1;
        }
        public int IsID(string ID)
        {
            if (ID.Length == 7)
            {
                if (ID.StartsWith("GT") || ID.StartsWith("GX"))
                {
                    string str = ID.Substring(2);
                    if (isDigitOnly(str) == true)
                    {
                        return 0;
                    }
                }
            }
            if (ID.Length == 8)
            {
                if (isDigitOnly(ID) == true)
                {
                    return 0;
                }
            }

            return -1;
        }
        public int IsGmail(string gmail)
        {
            string EmailFormat = "@gmail.com";
            if (gmail.Contains(EmailFormat))
            {
                return 0;
            }
            return -1;
        }
        public int IsNotNullNorSpecialCharacter(string input)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(input))
            {
                return 0;
            }
            return -1;
        }
        public int IsNotNull(string input)
        {
            if (input == null || input == "")
            {
                return -1;
            }
            return 0;
        }

        public bool isDigitOnly(string s)
        {
            foreach (char item in s)
            {
                if (item < '0' || item > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
