
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

           if(!text.StartsWith(prefix))
            {
                return new Match(false, text);
            }

            return new Match(true, text.Substring(prefix.Length));
        }
    }
}
