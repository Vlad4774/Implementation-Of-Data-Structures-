

using System.Reflection.Metadata;

namespace newJsonProject
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var integer = new Sequence(new Optional(new Character('-')), new Choice(new Character('0'), digits));
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var sign = new Optional(new Any("+-"));
            var exponent = new Any("eE");
            var exponentPart = new Optional(new Sequence(exponent, sign, digits));
            pattern = new Sequence(integer, fraction, exponentPart);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
