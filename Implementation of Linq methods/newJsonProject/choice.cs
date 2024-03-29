﻿namespace newJsonProject
{
    class Choice : IPattern
    {
        IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch result = new Match(false, text);
            foreach (var pattern in patterns)
            {
                result = pattern.Match(result.RemainingText());
                if (result.Success())
                {
                    return result;
                }
            }

            return result;
        }

        public void Add(IPattern newPattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = newPattern;
        }
    }
}