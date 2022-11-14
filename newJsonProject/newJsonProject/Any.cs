
namespace newJsonProject
{
    class Any : IPattern
    {
        string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            if (accepted.Contains(text[0]))
            {
                return new Match(true, text.Substring(1));
            }

            return new Match(false, text);
        }
    }
}
