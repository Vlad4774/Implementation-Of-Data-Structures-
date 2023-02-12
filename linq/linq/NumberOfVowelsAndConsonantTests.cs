
namespace linq
{
    public class NumberOfVowelsAndConsonantTests
    {
        [Fact]
        public void ReturnNumberOfVowels()
        {
            var numbers = new NumberOfVowelAndConsonant("ana are mere");
            Assert.Equal(6, numbers.ReturnNumberOfVowels());
            Assert.Equal(4, numbers.ReturnNumberOfConsonants());
        }

        [Fact]
        public void ReturnNumberOfConsonants()
        {
            var numbers = new NumberOfVowelAndConsonant("Hello World");
            Assert.Equal(7, numbers.ReturnNumberOfConsonants());
            Assert.Equal(3, numbers.ReturnNumberOfVowels());
        }
    }
}
