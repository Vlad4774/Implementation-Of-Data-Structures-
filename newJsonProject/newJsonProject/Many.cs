

namespace newJsonProject
{
    class Many : IPattern
    {
        IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
    }

        public IMatch Match(string text)
        {
            while (pattern.Match(text).Success())
            {
                text = text.Substring(1);
            }

            return new Match(true, text);
        }
    }
}
