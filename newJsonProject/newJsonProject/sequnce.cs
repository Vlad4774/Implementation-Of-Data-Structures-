
namespace newJsonProject
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string copy = text;
            IMatch consumed = new Match(true, text);
            foreach (var pattern in patterns)
            {
                consumed = pattern.Match(consumed.RemainingText());
                if (!consumed.Success())
                {
                    return new Match(false, copy);
                }
            }

            return consumed;
        }
    }
}
