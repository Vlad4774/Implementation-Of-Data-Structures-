using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace WorkWithStream
{
    public class streamTests
    {
        [Fact]
        public void WriteASimpleText()
        {
            string text = "Am reusit";
            var str = new StreamWriteAndRead(new MemoryStream(), false, false);
            str.Write(text);
            Assert.Equal($"{text}\r\n", str.Read());

        }

        [Fact]
        public void WriteATextWithMultipleLines()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            var str = new StreamWriteAndRead(new MemoryStream(), false, false);
            str.Write(text);
            Assert.Equal($"{text}\r\n", str.Read());

        }

        [Fact]
        public void WriteAEncryptedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            var str = new StreamWriteAndRead(new MemoryStream(), true, false);
            str.Write(text);
            Assert.Equal($"{text}\r\n", str.Read());
        }

        [Fact]
        public void WriteACompressedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            var str = new StreamWriteAndRead(new MemoryStream(), false, true);
            str.Write(text);
            Assert.Equal($"{text}\r\n", str.Read());
        }

        [Fact]
        public void WriteACompressedAndEncryptedText()
        {
            string text = "Am reusit \n sa scriu \n in fisier";
            var str = new StreamWriteAndRead(new MemoryStream(), true, true);
            str.Write(text);
            Assert.Equal($"{text}\r\n", str.Read());
        }
    }
}