
namespace newJsonProject
{
    interface IPattern
    {
        bool Match(string text);
    }
    class Choice
    {
        IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in patterns)
            {
                return pattern.Match(text);
            }

            return true;
        }
    }
}
