using System;

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
            int i = 0;
            do
            {
                if (input[i] == '\\' && !ContainCorectCharacters(input, i + 1))
                {
                    return false;
                }

                if (input[i] == '\\')
                {
                    i++;
                }

                i++;
            }
            while (i < input.Length);

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

            return "\"\\/bfnrst".Contains(input[position]);
        }

        static bool ValidUnicodeCharacter(string input)
        {
            input = input.ToUpper();
            foreach (var c in input)
            {
                if (!IsHex(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsHex(char c)
        {
            return char.IsLetterOrDigit(c);
        }
    }
}
