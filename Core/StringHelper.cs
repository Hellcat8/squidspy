using System;
using System.Text.RegularExpressions;

namespace squidspy.Core
{
    public static class StringHelper
    {
        public static string CleanLevelString(string input)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                input = input.ToLower().Replace("niveau ", "");

                return input;
            }
            return String.Empty;
        }

        public static bool HasUnwantedString(string s)
        {
            Regex reg = new Regex("/(&.+;)");

            return reg.IsMatch(s);
        }

        public static bool HasBadCondition(string s)
        {
            //string lower = s.ToLower();

            //if (lower.Contains("cra") ||
            //    lower.Contains("ecaflip") ||
            //    lower.Contains("eniripsa") ||
            //    lower.Contains("enutrof") ||
            //    lower.Contains("feca") ||
            //    lower.Contains("iop") ||
            //    lower.Contains("osamodas") ||
            //    lower.Contains("pandawa") ||
            //    lower.Contains("sacrieur") ||
            //    lower.Contains("sadida") ||
            //    lower.Contains("sram") ||
            //    lower.Contains("xelor"))
            //{
            //    return true;
            //}

            //if (lower.StartsWith(">") || lower.StartsWith(">") || lower.StartsWith("="))
            //{
            //    return true;
            //}

            return false;
        }

        public static string CleanCondition(string s)
        {
            string lower = s.ToLower();

            if (lower.Contains("10 sadida"))
            {
                // 'Classe 10 Sadida -> Classe différente de Sadida'
                s = s.Replace("10", "différente de");
            }

            if (lower.StartsWith(">") || lower.StartsWith(">") || lower.StartsWith("="))
            {
                // '> 20' -> 'Alignement > 20'
                s = $"Alignement {s}";
            }

            return s;
        }
    }
}
