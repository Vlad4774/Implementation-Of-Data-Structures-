
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
            int falsePropositions = 0;
            foreach (var pattern in patterns)
            {
                if(!pattern.Match(text))
                {
                    falsePropositions++;
                }
            }

            return !(falsePropositions == patterns.Length);
        }
    }
}
