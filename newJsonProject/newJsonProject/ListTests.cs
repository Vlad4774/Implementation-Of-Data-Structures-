
namespace newJsonProject
{
    public class ListTests
    {
        [Theory]
        [InlineData("1,2,3", "")]
        [InlineData("1,2,3,", ",")]
        [InlineData("1a", "a")]
        [InlineData("abc", "abc")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void FirstCases(string text, string result)
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match(text).Success());
            Assert.Equal(result, a.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22", "")]
        [InlineData("1 \n;", " \n;")]
        [InlineData("abc", "abc")]

        public void JsonCases(string text, string result)
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match(text).Success());
            Assert.Equal(result, list.Match(text).RemainingText());
        }
    }
}
