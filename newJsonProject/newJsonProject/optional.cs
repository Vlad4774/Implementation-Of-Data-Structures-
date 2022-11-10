
namespace newJsonProject
{
    class Optional : IPattern
    {
        IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text).Success() ? new Match(true, text.Substring(1)) : new Match(true, text);
        }
    }
}
