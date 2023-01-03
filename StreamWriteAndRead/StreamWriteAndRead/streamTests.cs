namespace StreamWriteAndRead
{
    public class streamTests
    {
        [Fact]
        public void WriteASimpleText()
        {
            string text = "Am reusit";
            string resultText = text + "\r" + "\n";
            var str = new Stream();
            str.Write(text);
            Assert.Equal(resultText, str.Read());

        }

        [Fact]
        public void WriteATextWithMultipleLines()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new Stream();
            str.Write(text);
            Assert.Equal(resultText, str.Read());

        }

        [Fact]
        public void WriteATextInANewFileCreateByProject()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new Stream();
            str.Write(text);
            Assert.Equal(resultText, str.Read());

        }
    }
}