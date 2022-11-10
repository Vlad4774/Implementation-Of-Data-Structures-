
namespace newJsonProject
{
    public class sequenceTests
    {
        [Fact]
        public void CaseTrueWithab()
        {
            var ab = new Sequence(new Character('a'),
                                  new Character('b'));
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
            Assert.True(ab.Match("abcd").Success());
        }

        [Theory]
        [InlineData("ax")]
        [InlineData("def")]
        [InlineData("")]
        [InlineData(null)]

        public void CaseFalseWithab(string parameter)
        {
            var ab = new Sequence(new Character('a'),
                                  new Character('b'));
            Assert.False(ab.Match(parameter).Success());
            Assert.Equal(parameter, ab.Match(parameter).RemainingText());
        }

        [Fact]
        public void CaseTrueWithabc()
        {
            var ab = new Sequence(new Character('a'),
                                  new Character('b'));
            var abc = new Sequence(ab,
                                   new Character('c'));
            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Theory]
        [InlineData("def")]
        [InlineData("abx")]
        [InlineData("")]
        [InlineData(null)]

        public void CaseFalseWithabc(string parameter)
        {
            var ab = new Sequence(new Character('a'),
                                  new Character('b'));
            var abc = new Sequence(ab,
                                   new Character('c'));
            Assert.False(abc.Match(parameter).Success());
            Assert.Equal(parameter, abc.Match(parameter).RemainingText());
        }

        [Theory]
        [InlineData("u1234", "")]
        [InlineData("uabcdef", "ef")]
        [InlineData("uB005 ab", " ab")]

        public void CaseTrueWithHex(string parameter, string result)
        {
            var hex = new Choice(new Range('0', '9'),
                                 new Range('a', 'f'),
                                 new Range('A', 'F'));

            var hexSeq = new Sequence(new Character('u'),
                                     new Sequence(hex, hex, hex, hex));
            Assert.True(hexSeq.Match(parameter).Success());
            Assert.Equal(result, hexSeq.Match(parameter).RemainingText());
        }
    }
}