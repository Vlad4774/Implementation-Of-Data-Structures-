
namespace newJsonProject
{
    public class textTests
    {
        [Theory]
        [InlineData("true", "true", "")]
        [InlineData("true", "trueX", "X")]
        [InlineData("false", "false", "")]
        [InlineData("false", "falseX", "X")]
        [InlineData("", "true", "true")]
        public void CasesTrue(string prefix, string text, string result)
        {
            var parameter = new Text(prefix);
            Assert.True(parameter.Match(text).Success());
            Assert.Equal(result, parameter.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("true", "false", "false")]
        [InlineData("true", "", "")]
        [InlineData("true", null, null)]
        [InlineData("false", "true", "true")]
        [InlineData("false", "", "")]
        [InlineData("false", null, null)]
        [InlineData("", null, null)]
        public void CasesFalse(string prefix, string text, string result)
        {
            var parameter = new Text(prefix);
            Assert.False(parameter.Match(text).Success());
            Assert.Equal(result, parameter.Match(text).RemainingText());
        }
    }
}
