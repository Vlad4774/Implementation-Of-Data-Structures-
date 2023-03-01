

namespace linq
{
    public class LetterWithMaxApperenceInAStringTests
    {
        [Fact]
        public void ReturnsCorrectLetter()
        {
            var givenString = new LetterWithMaxApperenceInAString("Vlllad");
            Assert.Equal(givenString.LetterWithMaxApperence(), 'l');
        }

        [Fact]
        public void ReturnsCorrectLetterInALongString()
        {
            var givenString = new LetterWithMaxApperenceInAString("Ana are mere, portocale, aaaa, aur, atc");
            Assert.Equal(givenString.LetterWithMaxApperence(), 'a');
        }
    }
}
