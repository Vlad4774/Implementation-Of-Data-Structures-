
namespace linq
{
    public class stringToIntTests
    {
        [Fact]
        public void ReturnsCorrectNumberIfIsUnder100()
        {
            var stringToNumber = new stringToInt("99");
            Assert.Equal(99, stringToNumber.StringToInt());
        }

        [Fact]
        public void ReturnsCorrectNumberIfIsUnder1000()
        {
            var stringToNumber = new stringToInt("745");
            Assert.Equal(745, stringToNumber.StringToInt());
        }

        [Fact]
        public void ReturnsCorrectNumberIfIsUnder10000()
        {
            var stringToNumber = new stringToInt("1298");
            Assert.Equal(1298, stringToNumber.StringToInt());
        }

        [Fact]
        public void ThrowsExceptionIfStringHaveALetter()
        {
            var stringToNumber = new stringToInt("745c");
            Assert.Throws<ArgumentException>(() => stringToNumber.StringToInt());
        }
    }
}
