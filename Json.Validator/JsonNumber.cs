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
            return IsInteger(Integer(input, indexOfDot, indexOfExponent)) && IsFraction(Fraction(input, indexOfDot, indexOfExponent)) && IsExponent(Exponent(input, indexOfExponent));
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

        static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1 && indexOfExponent != -1)
            {
                return input.Substring(indexOfDot, indexOfExponent - indexOfDot);
            }
            else if (indexOfDot != -1)
            {
                return input.Substring(indexOfDot, input.Length - indexOfDot);
            }

            return null;
        }

        static bool IsFraction(string fractional)
        {
            if (fractional == null)
            {
                return true;
            }
            else if (fractional.Length == 1)
            {
                return false;
            }

            for (int i = 1; i < fractional.Length; i++)
            {
                if (ContainUnvalidCharacter(fractional[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return null;
            }

            return input.Substring(indexOfExponent + 1, input.Length - indexOfExponent - 1);
        }

        static bool IsExponent(string exponent)
        {
            if (exponent == null)
            {
                return true;
            }
            else if (ContainUnvalidCharacter(exponent[exponent.Length - 1]))
            {
                return false;
            }

            for (int i = 0; i < exponent.Length; i++)
            {
                if (ContainUnvalidCharacter(exponent[i]))
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
