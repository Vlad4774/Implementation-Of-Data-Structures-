

namespace newJsonProject
{
    public class rangeTests
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("fab")]
        [InlineData("bcd")]

        public void CasesTrue(string text)
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match(text).Success());

        }

        [Theory]
        [InlineData("1ab")]
        [InlineData("")]
        [InlineData(null)]

        public void CaseFalse(string text)
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(text).Success());
        }
    }
}
