

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
            IMatch result = new Match(true, text);
            while(result.Success())
            {
                result = pattern.Match(result.RemainingText());
            }

            return new Match(true, result.RemainingText());
        }
    }
}
