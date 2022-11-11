using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newJsonProject
{
    public class optionalTests
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aabc", "abc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void CasesWithA(string text, string result)
        {
            var a = new Optional(new Character('a'));
            Assert.Equal(result, a.Match(text).RemainingText());
        }

        [Theory]
        [InlineData("123", "123")]
        [InlineData("-123", "123")]
        public void CasesWithSign(string text, string result)
        {
            var sign = new Optional(new Character('-'));
            Assert.Equal(result, sign.Match(text).RemainingText());
        }

        [Fact]
        public void NewCase()
        {
            var param = new Optional(new Sequence(new Character('a'), new Character('b')));
            Assert.Equal("ccd", param.Match("abccd").RemainingText());
        }
    }
}
