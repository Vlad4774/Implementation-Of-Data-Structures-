using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && HaveQuotes(input);
        }

        static bool HaveQuotes(string input)
        {
            return input[0] == '"' && input[input.Length - 1] == '"' && input.Length > 1;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
