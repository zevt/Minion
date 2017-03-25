using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Minion
{
    class RegexUltilities
    {
        bool invalid = false;
        public static string sMissingIMEI = "Missing";
        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public bool IsValidIMEI(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 

            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;


            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn, @"^\d{15}", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public bool ContainIMEI(string StrIn)
        {
            char[] Separators = { '\n', '\t', ' ' };
            string[] SolidStrings = StrIn.Split(Separators);
            int index = 0;
            while (index < SolidStrings.GetLength(0))
            {
                if (IsValidIMEI(SolidStrings[index]))
                    return true;
                else ++index;
            }
            return false;
        }
        public string GetIMEI(string StrIn)
        {
            char[] Separators = { '\n', '\t', ' ' };
            string[] SolidStrings = StrIn.Split(Separators);
            int index = 0;
            while (index < SolidStrings.GetLength(0))
            {
                if (IsValidIMEI(SolidStrings[index]))
                    return SolidStrings[index];
                else ++index;
            }
            return null;
        }
        public bool IsUnlockOrder(string strIn)
        {
            /*
            if (strIn.Contains("26") || strIn.Contains("28") || strIn.Contains("44") || strIn.Contains("54")
                || strIn.Contains("64") || strIn.Contains("99") || strIn.Contains("115"))
                */
            if (strIn == ("26") || strIn == ("28") || strIn == ("44") || strIn == ("54")
                || strIn == ("64") || strIn == ("99") || strIn == ("115"))
            {
                return true;
            }
            else return false;
        }
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        public string CheckAndCorrectIMEI(string strIMEI)
        {
            string pattern  = @"[\d]{15}";
            Match mat = Regex.Match(strIMEI, pattern);
            if (mat.Success)
                return mat.Value;
            else
                return sMissingIMEI;
        }
    }
}
