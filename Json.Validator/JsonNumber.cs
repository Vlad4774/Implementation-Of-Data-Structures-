using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNotNullOrEmpty(input) && !ContainLetters(input);
        }

        static bool IsNotNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
