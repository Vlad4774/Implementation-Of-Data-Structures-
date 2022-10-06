using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && HaveQuotes(input) && !ContainControlCharacters(input);
        }

        static bool HaveQuotes(string input)
        {
            return input[0] == '"' && input[input.Length - 1] == '"' && input.Length > 1;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if ((int)c < ' ')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
