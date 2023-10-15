
namespace newJsonProject
{
    public class OneOrMoreTests
    {
        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]

        void CasesTrue(string text, string result)
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match(text).Success());
            Assert.Equal(result, a.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]


        void CasesFalse(string text, string result)
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match(text).Success());
            Assert.Equal(result, a.Match(text).RemainingText());
        }
    }
}
