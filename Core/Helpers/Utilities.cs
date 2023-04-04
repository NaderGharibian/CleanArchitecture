using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Core.Helper;

public static class Utilities
{
    public static bool IsValidDate(string date)
    {
        DateTime temp;
        if (DateTime.TryParse(date, out temp)) return true;
        
        return false;   
    }
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(phoneNumber, "IN"));
    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    public static class EnvironmentHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetSolutionName()
        {
            var solutionFullPath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            var tempStrings = solutionFullPath.Split('\\');

            var solutionName = tempStrings[^1];
            return solutionName;
        }
    }
}