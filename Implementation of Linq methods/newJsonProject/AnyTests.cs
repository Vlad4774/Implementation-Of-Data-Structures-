
namespace newJsonProject
{
    public class AnyTests
    {
        [Theory]
        [InlineData("eE", "ea", "a")]
        [InlineData("eE", "Ea", "a")]
        [InlineData("-+", "+3", "3")]
        [InlineData("-+", "-2", "2")]
        public void CasesTrue(string accepted, string text, string result)
        {
            var e = new Any(accepted);
            Assert.True(e.Match(text).Success());
            Assert.Equal(result, e.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("eE", "a", "a")]
        [InlineData("eE", "", "")]
        [InlineData("eE", null, null)]
        [InlineData("-+", "2", "2")]
        [InlineData("-+", "", "")]
        [InlineData("-+", null, null)]
        public void CasesFalse(string accepted, string text, string result)
        {
            var e = new Any(accepted);
            Assert.False(e.Match(text).Success());
            Assert.Equal(result, e.Match(text).RemainingText());
        }
    }
}
