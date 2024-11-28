using System.Text.RegularExpressions;

namespace EMTestTask.Validator
{
    public static class CustomerValidator
    {
        public static bool IsValidName(string value)
        {
            string specialSymbolPattern = @"[^\p{L}\s_-]";
            Regex regex = new Regex(specialSymbolPattern);
            return !string.IsNullOrWhiteSpace(value) && !regex.IsMatch(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) 
                return false;
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) 
                return false;
            var phonePattern = @"^[0-9]{10,15}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
    }
}
