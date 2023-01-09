using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace WorkWithStream
{
    public class streamTests
    {
        [Fact]
        public void WriteASimpleText()
        {
            string text = "Am reusit";
            string resultText = text + "\r" + "\n";
            var str = new StreamWriteAndRead(new MemoryStream(), false, false);
            str.Write(text);
            Assert.Equal(resultText, str.Read());

        }

        [Fact]
        public void WriteATextWithMultipleLines()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new StreamWriteAndRead(new MemoryStream(), false, false);
            str.Write(text);
            Assert.Equal(resultText, str.Read());

        }

        [Fact]
        public void WriteAEncryptedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new StreamWriteAndRead(new MemoryStream(), true, false);
            str.Write(text);
            Assert.Equal(resultText, str.Read());
        }

        [Fact]
        public void WriteACompressedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new StreamWriteAndRead(new MemoryStream(), false, true);
            str.Write(text);
            Assert.Equal(resultText, str.Read());
        }

        [Fact]
        public void WriteACompressedAndEncryptedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            string resultText = text + "\r" + "\n";
            var str = new StreamWriteAndRead(new MemoryStream(), true, true);
            str.Write(text);
            Assert.Equal(resultText, str.Read());
        }
    }
}