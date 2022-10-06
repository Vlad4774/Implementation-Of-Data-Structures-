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

            const int four = 4;
            if (input[position] == 'u')
            {
                if (input.Length - four > 1)
                {
                    return ValidUnicodeCharacter(input.Substring(position + 1, four));
                }

                return false;
            }

            char[] characters = { '"', '\\', '/', 'b', 'f', 'n', 'r', 's', 't' };
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == input[position])
                {
                    return true;
                }
            }

            return false;
        }

        static bool ValidUnicodeCharacter(string input)
        {
            return input.All(char.IsLetterOrDigit);
        }
    }
}
