namespace StreamWriteAndRead
{
    public class streamTests
    {
        [Fact]
        public void WriteASimpleText()
        {
            string text = "Am reusit";
            string resultText = text + "\r" + "\n";
            var str = new stream();
            Assert.Equal(resultText, str.WriteAndRead(text, "C:\\Users\\vladb\\OneDrive\\Documente\\file1.txt"));

        }

        [Fact]
        public void WriteATextWithMultipleLines()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new stream();
            Assert.Equal(resultText, str.WriteAndRead(text, "C:\\Users\\vladb\\OneDrive\\Documente\\file2.txt"));

        }

        [Fact]
        public void WriteATextInANewFileCreateByProject()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new stream();
            Assert.Equal(resultText, str.WriteAndRead(text, "C:\\Users\\vladb\\OneDrive\\Documente\\newfile.txt"));

        }
    }
}