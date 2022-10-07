using System;
using System.Linq;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && HaveQuotes(input) && !ContainControlCharacters(input) && ContainEscapedCharacters(input);
        }

        static bool HaveQuotes(string input)
        {
            return input.Length > 1 && input[0] == '"' && input[input.Length - 1] == '"';
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if (c < ' ')
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainEscapedCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && !ContainCorectCharacters(input, i + 1))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainCorectCharacters(string input, int position)
        {
            if (position == input.Length - 1)
            {
                return false;
            }

            const int length = 4;
            if (input[position] == 'u')
            {
                if (input.Length - length > 1)
                {
                    return ValidUnicodeCharacter(input.Substring(position + 1, length));
                }

                return false;
            }

            if (input[position - 1 - 1] == '\\')
            {
                return true;
            }

            string[] characters = { "\"", @"\", "/", "b", "f", "n", "r", "s", "t" };
            string character_from_position = input[position].ToString();
            return characters.Contains(character_from_position);
        }

        static bool ValidUnicodeCharacter(string input)
        {
            string input_upper_case = input.ToUpper();
            for (int i = 0; i < input_upper_case.Length; i++)
            {
                if ((input_upper_case[i] < 'A' || input_upper_case[i] > 'Z') && (input_upper_case[i] < '0' || input_upper_case[i] > '9'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
