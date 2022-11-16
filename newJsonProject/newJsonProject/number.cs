

using System.Reflection.Metadata;

namespace newJsonProject
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var firstDigit = new Range('1', '9');
            var integer = new Choice(new Sequence(new Optional(new Character('-')), firstDigit, new Optional(digits)),
                                     new Sequence(new Optional(new Character('-')), new Character('0')));
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var sign = new Optional(new Choice(new Character('-'), new Character('+')));
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
