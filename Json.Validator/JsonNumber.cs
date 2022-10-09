using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && !ContainUnvalidCharacters(input) && !CheckFirstDigitIs0(input) && TheNumberEndsCorrectly(input);
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainUnvalidCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] < '0' || input[i] > '9') && !ContainValidCharacter(input, i))
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckFirstDigitIs0(string input)
        {
            return input[0] == '0' && input.Length > 1;
        }

        static bool ContainValidCharacter(string input, int position)
        {
            if (input[position] == '-' || input[position] == '+' || input[position] == '.')
            {
                return NumberOfOccurrences(input, position);
            }
            else if (input[position] == 'e' || input[position] == 'E')
            {
                return NumberOfOccurrences(input, position) && ValidationOfExponent(input, position + 1);
            }

            return false;
        }

        static bool NumberOfOccurrences(string input, int position)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == input[position])
                {
                    count++;
                }
            }

            return count == 1;
        }

        static bool ValidationOfExponent(string input, int position)
        {
            for (int i = position; i < input.Length; i++)
            {
                if ((input[i] < '0' || input[i] > '9') && input[i] != '+' && input[i] != '-')
                {
                    return false;
                }
            }

            return true;
        }

        static bool TheNumberEndsCorrectly(string input)
        {
            return !(input[input.Length - 1] < '0' || input[input.Length - 1] > '9');
        }
    }
}
