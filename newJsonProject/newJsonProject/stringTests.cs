
namespace newJsonProject
{
    public class stringTests
    {
        [Fact]
        public void IsDoubleQuoted()
        {
            var str = new String();
            Assert.True(str.Match(Quoted("abc")).Success());
            Assert.Equal("", str.Match(Quoted("abc")).RemainingText());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            var str = new String();
            Assert.False(str.Match("abc\"").Success());
            Assert.Equal("abc\"", str.Match("abc\"").RemainingText());
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            var str = new String();
            Assert.False(str.Match("\"").Success());
            Assert.Equal("\"", str.Match("\"").RemainingText());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var str = new String();
            Assert.False(str.Match(Quoted("a\nb\rc")).Success());
            Assert.Equal(Quoted("a\nb\rc"), str.Match(Quoted("a\nb\rc")).RemainingText());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var str = new String();
            Assert.True(str.Match(Quoted("⛅⚾")).Success());
            Assert.Equal("", str.Match(Quoted("⛅⚾")).RemainingText());
        }
        public static string Quoted(string text)
    => $"\"{text}\"";
    }
}
