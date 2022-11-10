
namespace newJsonProject
{
    class Range : IPattern
    {
        char start;
        char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || (text[0] < start || text[0] > end))
            {
                return new Match(false, text);
            }

            return new Match(true, text.Substring(1));
        }
    }
}
