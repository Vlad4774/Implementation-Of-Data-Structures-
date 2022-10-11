using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsIntegrer(input);
        }

        static bool IsIntegrer(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
