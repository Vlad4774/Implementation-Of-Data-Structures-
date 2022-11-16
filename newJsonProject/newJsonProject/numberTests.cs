

using static System.Net.Mime.MediaTypeNames;

namespace newJsonProject
{
    public class numberTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("76")]
        [InlineData("986412")]
        public void CanBeAPozitiveNumber(string text)
        {
            var number = new Number();
            Assert.True(number.Match(text).Success());
        }

        [Theory]
        [InlineData("-0", "")]
        [InlineData("-2", "")]
        [InlineData("-345", "")]
        [InlineData("-986412", "")]
        public void CanBeANegativeNumber(string text, string result)
        {
            var number = new Number();
            Assert.Equal(result, number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Theory]
        [InlineData("-2.321", "")]
        [InlineData("-345.121", "")]
        [InlineData("0.1231", "")]
        public void CanBeAFractionalNumber(string text, string result)
        {
            var number = new Number();
            Assert.Equal(result, number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Theory]
        [InlineData("-2.321e+12", "")]
        [InlineData("3E3", "")]
        [InlineData("0.1231e+12", "")]
        [InlineData("-345.121E1", "")]
         public void CanBeAExponantialNumber(string text, string result)
        {
            var number = new Number();
            Assert.Equal(result, number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }
    }
}
