using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny("eE".ToCharArray());
            return IsInteger(input, indexOfDot, indexOfExponent);
        }

        static bool IsInteger(string input, int indexOfDot, int indexOfExponent)
        {
            string integer = input;
            if (indexOfDot != -1)
            {
                integer = input.Substring(0, indexOfDot);
            }
            else if (indexOfExponent != -1)
            {
                integer = input.Substring(0, indexOfExponent);
            }

            foreach (char c in integer)
            {
                if (ContainUnvalidCharacter(c) && c != '-')
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainUnvalidCharacter(char c)
        {
            return c < '0' || c > '9';
        }
    }
}
