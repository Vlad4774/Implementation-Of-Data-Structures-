﻿
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

        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]
        [InlineData("a9")]
        [InlineData("f8")]
        [InlineData("A9")]
        [InlineData("F8")]
        public void CasesTrueForHex(string text)
        {
            var digit = new Choice(new Character('0'),
                                   new Range('1', '9'));
            var hex = new Choice(
                           digit,
                     new Choice(
                     new Range('a', 'f'),
                       new Range('A', 'F')));
            Assert.True(hex.Match(text));
        }

        [Theory]
        [InlineData("g8")]
        [InlineData("G8")]
        [InlineData("")]
        [InlineData(null)]
        public void CasesFalseForHex(string text)
        {
            var digit = new Choice(new Character('0'),
                                   new Range('1', '9'));
            var hex = new Choice(
                           digit,
                     new Choice(
                     new Range('a', 'f'),
                       new Range('A', 'F')));
            Assert.False(hex.Match(text));
        }
    }
}
