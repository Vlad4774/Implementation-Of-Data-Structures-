
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
            return string.IsNullOrEmpty(text) || !text.StartsWith(prefix) ? new Match(false, text) : new Match(true, text.Substring(prefix.Length));
        }
    }
}
