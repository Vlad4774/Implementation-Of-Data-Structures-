
namespace newJsonProject
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(new Range('A', 'Z'),
                                 new Range('a', 'z'),
                                 new Range('0', '9'));
            var accepted = new Choice(new Range(' ', '!'),
                                      new Range('#', '\u005B'),
                                      new Range('\u005D', '\uFFFF'));
            var unicode = new Sequence(new Character('u'), hex, hex, hex, hex);
            var escapedCharacters = new Sequence(new Character('\\'), new Choice(unicode, new Any("\"\\/bfnrst")));
            var characters = new Choice(escapedCharacters, accepted);
            pattern = new Sequence(new Character('"'), new OneOrMore(characters), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
