using System;
using System.Text.RegularExpressions;

namespace squidspy.Core
{
    public static class StringHelper
    {
        public static string CleanString(string input)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                input = input.Replace("&agrave;", "à");
                input = input.Replace("&eacute;", "é");

                return input;
            }
            return String.Empty;
        }

        public static bool HasUnwantedString(string s)
        {
            Regex reg = new Regex("/(&.+;)/ig");

            return reg.IsMatch(s);
        }
    }
}
