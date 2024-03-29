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
            if (integer.StartsWith('0') && integer.Length > 1)
            {
                return false;
            }

            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
            }

            return HaveDigits(integer);
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
            return fractional == null || HaveDigits(fractional[1..]);
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

            exponent = exponent[1..];
            if (exponent.StartsWith('-') || exponent.StartsWith('+'))
            {
                exponent = exponent[1..];
            }

            return HaveDigits(exponent);
        }

        static bool HaveDigits(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}
