using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && !ContainUnvalidCharacters(input) && !CheckFirstDigitIs0(input);
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
            return input[position] == '-';
        }
    }
}
