using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExtensionMethods
{
    /// <summary>
    /// The static UtilityHelper class
    /// Contains all extensions methods for given questions
    /// </summary>
    public static class UtilityHelper
    {
        /// <summary>
        /// Question 1
        /// Extension Method to convert input string with 
        /// uppercase charactes to lowercase 
        /// </summary>
        /// <param name="input"></param>
        /// <returns> Returns a string with uppercase characters converted to lowercase  </returns>
        public static String createLowerCase(this String input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    str[i] = (char)(str[i] + 32);
                else if (str[i] >= 'a' && str[i] <= 'z')
                    str[i] = (char)(str[i] - 32);
            }
            return str.ToString();
        }

        /// <summary>
        /// Question 2
        /// Extension Method to convert input string with 
        /// lowercase charactes to uppercase 
        /// </summary>
        /// <param name="input"></param>
        /// <returns> Returns a string with lowercase characters converted to uppercase</returns>
        public static String createUpperCase(this String input)
        {
            StringBuilder str = new StringBuilder(input);
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                    str[i] = (char)(str[i] - 32);
                else if (str[i] >= 'A' && str[i] <= 'Z')
                    str[i] = (char)(str[i] + 32);

            }
            return str.ToString();
        }

        /// <summary>
        /// Question 3
        /// Extension Method to converts the specified string to title case
        /// </summary>
        /// <param name="s"></param>
        /// <returns> Returns a string with Title case </returns>
        /// 
        public static string ToTitleCase(this string s) =>
        CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());

       

        /// <summary>
        /// Question 4
        /// Extension method to check characters from
        /// given input string are in lower case or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>returns a boolean </returns>
        public static bool CheckUpperCase(this String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Question 5
        ///  Extension method to return a capitalized version of given input string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns> returns a string </returns>
        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }



        /// <summary>
        /// Question 6
        /// Extension method to check characters from
        /// given input string are in uppercase case or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>returns a boolean </returns>
        public static bool CheckLowerCase(String str)
        {
            int ln = str.Length;

            for (int i = 0; i < ln; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Question 7
        /// Extension Method to check whether given 
        /// input string can be converted to a valid numeric value or not
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns a boolean </returns>
        public static bool ValidNumeric(this String input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            return isNumeric;
        }

        /// <summary>
        /// Question 8
        /// Extension Method to remove the last character from given the string
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns>return a string wihout last character </returns>
        public static String removeLastChar(this String s)
        {
            return (s == null || s.Length == 0)
              ? null
              : (s.Substring(0, s.Length - 1));
        }

        /// <summary>
        /// Question 9
        /// Extension method to get word count from an input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns> returns a integer </returns>
        public static int GetWordCount(this String input)
        {

            var wordCount = 0;
            for (var i = 0; i < input.Length; i++)
                if (input[i] == ' ' || i == input.Length - 1)
                    wordCount++;
            return wordCount;
        }

        /// <summary>
        /// Question 10
        /// Extension Method to convert an input string to integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns a integer </returns>
        public static int StringToInt(this String input)
        {
            int x = 0;
            Int32.TryParse(input, out x);
            return x;
        }
    }
}
