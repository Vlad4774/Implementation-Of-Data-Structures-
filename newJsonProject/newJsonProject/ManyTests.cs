
using static System.Net.Mime.MediaTypeNames;

namespace newJsonProject
{
    public class ManyTests
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aaaabc", "bc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void CaseswithCharacter(string text, string result)
        {
            var a = new Many(new Character('a'));
            Assert.Equal(result, a.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("12345ab123", "ab123")]
        [InlineData("ab", "ab")]
        public void CaseswithRange(string text, string result)
        {
            var digits = new Many(new Range('0', '9'));
            Assert.Equal(result, digits.Match(text).RemainingText());
        }

        [Fact]
        public void NewCase()
        {
                var param = new Many(new Sequence(new Character('a'), new Character('b')));
                Assert.Equal("ccd", param.Match("ababccd").RemainingText());
        }
    }
}
