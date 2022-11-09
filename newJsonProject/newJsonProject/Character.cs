
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
            var result = new Match(false, text);
            if (string.IsNullOrEmpty(text) || text[0] != pattern)
            {
                return result;
            }

            result = new Match(true, text);
            return result;
        }
    }
}
