
namespace newJsonProject
{
    public class stringTests
    {
        [Fact]
        public void IsDoubleQuoted()
        {
            var str = new String();
            Assert.True(str.Match(Quoted("abc")).Success());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            var str = new String();
            Assert.False(str.Match("abc\"").Success());
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            var str = new String();
            Assert.False(str.Match("\"").Success());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var str = new String();
            Assert.False(str.Match(Quoted("a\nb\rc")).Success());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var str = new String();
            Assert.True(str.Match(Quoted("⛅⚾")).Success());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            var str = new String();
            Assert.True(str.Match(Quoted(@"\""a\"" b")).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var str = new String();
            Assert.True(str.Match(Quoted(@"a \b b")).Success());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            var str = new String();
            Assert.True(str.Match(Quoted(@"a \n b")).Success());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var str = new String();
            Assert.True(str.Match(Quoted(@"a \u26Be b")).Success());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            var str = new String();
            Assert.False(str.Match(Quoted(@"a\x")).Success());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            var str = new String();
            Assert.False(str.Match(Quoted(@"a\")).Success());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            var str = new String();
            Assert.False(str.Match(Quoted(@"a\u")).Success());
            Assert.False(str.Match(Quoted(@"a\u123")).Success());
        }

        public static string Quoted(string text)
    => $"\"{text}\"";
    }
}
