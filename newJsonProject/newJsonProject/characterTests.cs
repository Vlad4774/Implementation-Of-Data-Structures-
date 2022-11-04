

namespace newJsonProject
{
    public class characterTests
    {
        [Theory]
        [InlineData('a', "abc")]
        [InlineData('f', "fab")]
        [InlineData('x', "xecd")]

        public void CasesTrue(char letter, string text)
        {
            var character = new Character(letter);
            Assert.True(character.Match(text));

        }

        [Theory]
        [InlineData('a', "1ab")]
        [InlineData('a', "")]
        [InlineData('b', null)]

        public void CaseFalse(char letter, string text)
        {
            var character = new Character(letter);
            Assert.False(character.Match(text));
        }
    }
}
