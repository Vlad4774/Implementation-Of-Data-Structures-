
namespace newJsonProject
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
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    var isTrue = new Match(true, text);
                    return isTrue;
                }
            }

            var result = new Match(false, text);
            return result;
        }
    }
}
