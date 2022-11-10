
namespace newJsonProject
{
    class Text
    {
        string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }    

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] != text[i])
                {
                    return new Match(false, text);
                }
            }

            return new Match(true, text.Substring(prefix.Length));
        }
    }
}
