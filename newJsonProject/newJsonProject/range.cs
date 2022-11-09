
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
            var result = new Match(false, text);
            if (string.IsNullOrEmpty(text))
            {
                return result;
            }

            if (text[0] < start || text[0] > end)
            {
                return result;
            }

            result = new Match(true, text);
            return result; 
        }
    }
}
