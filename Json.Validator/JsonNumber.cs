using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNotNullOrEmpty(input);
        }

        static bool IsNotNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
