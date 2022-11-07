
namespace newJsonProject
{
    public class choiseTests
    {
        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]

        public void CasesTrue(string text)
        {
            var digit = new Choice (new Character('0'),
                                   new Range('1', '9') );
            Assert.True(digit.Match(text));
        }

        [Theory]
        [InlineData("a9")]
        [InlineData("")]
        [InlineData(null)]

        public void CasesFalse(string text)
        {
            var digit = new Choice(new Character('0'),
                                   new Range('1', '9'));
            Assert.False(digit.Match(text));
        }
    }
}
