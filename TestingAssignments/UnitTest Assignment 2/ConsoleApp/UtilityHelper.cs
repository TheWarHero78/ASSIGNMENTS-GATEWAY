using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExtensionMethods
{
    public static class UtilityHelper
    {
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

        public static string ToTitleCase(this string s) =>
     CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());

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

        public static string FirstLetterToUpper( this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }


        public static bool ValidNumeric(this String input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            return isNumeric;
        }

        public static String removeLastChar( this String s)
        {
            return (s == null || s.Length == 0)
              ? null
              : (s.Substring(0, s.Length - 1));
        }
        public static int GetWordCount(this String input)
        {

            int ln = input.Length;
            String[] words = input.Split(' ');

            return words.Length;
        }
        public static int StringToInt(this String input)
        {
            int x = 0;

            Int32.TryParse(input, out x);
            return x;
        }
    }
    }
