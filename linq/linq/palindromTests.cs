

namespace linq
{
    public class palindromTests
    {
        [Fact]
        public void ReturnsCorrectPalindrom()
        {
            var givenString = new palindrom("aba");
            var result = givenString.AllPalindroms();
            var expected = new List<string> { "a", "aba", "a" };
            Assert.Equal(expected, result);
        }
    }
}
