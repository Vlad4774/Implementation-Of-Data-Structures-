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
            return IsInteger(Integer(input, indexOfDot, indexOfExponent))
               && IsFraction(Fraction(input, indexOfDot, indexOfExponent))
               && IsExponent(Exponent(input, indexOfExponent));
        }

        static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1)
            {
                return input[..indexOfDot];
            }

            if (indexOfExponent != -1)
            {
                return input[..indexOfExponent];
            }

            return input;
        }

        static bool IsInteger(string integer)
        {
            if (integer[0] == '0' && integer.Length > 1)
            {
                return false;
            }

            if (integer[0] == '-')
            {
                return IsDigit(integer, 1, integer.Length);
            }

            return IsDigit(integer, 0, integer.Length);
        }

        static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1 && indexOfExponent != -1)
            {
                return input[indexOfDot..indexOfExponent];
            }

            if (indexOfDot == -1)
            {
                return null;
            }

            return input[indexOfDot..];
        }

        static bool IsFraction(string fractional)
        {
            if (fractional == null)
            {
                return true;
            }

            if (fractional.Length == 1)
            {
                return false;
            }

            return IsDigit(fractional, 1, fractional.Length);
        }

        static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return null;
            }

            return input[indexOfExponent..];
        }

        static bool IsExponent(string exponent)
        {
            if (exponent == null)
            {
                return true;
            }

            if (!IsDigit(exponent, exponent.Length - 1, exponent.Length))
            {
                return false;
            }

            if (exponent[1] != '+' && exponent[1] != '-' && !IsDigit(exponent, 1, 1 + 1))
            {
                return false;
            }

            const int start = 2;
            return IsDigit(exponent, start, exponent.Length);
        }

        static bool IsDigit(string input, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
