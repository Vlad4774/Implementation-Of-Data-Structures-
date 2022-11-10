
namespace newJsonProject
{
    class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || text[0] != pattern)
            {
                return new Match(false, text);
            }

            return new Match(true, text);
        }
    }
}
