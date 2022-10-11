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
            return IsInteger(Integer(input, indexOfDot, indexOfExponent));
        }

        static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1)
            {
                return input.Substring(0, indexOfDot);
            }
            else if (indexOfExponent != -1)
            {
                return input.Substring(0, indexOfExponent);
            }

            return input;
        }

        static bool IsInteger(string integer)
        {
            if (integer[0] == '0' && integer.Length > 1)
            {
                return false;
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

        static string Fractional(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1 && indexOfExponent != -1)
            {
                return input.Substring(indexOfDot + 1, indexOfExponent - indexOfDot);
            }
            else if (indexOfDot != -1)
            {
                return input.Substring(indexOfDot + 1, input.Length - indexOfDot - 1);
            }

            return null;
        }

        static bool ContainUnvalidCharacter(char c)
        {
            return c < '0' || c > '9';
        }
    }
}
