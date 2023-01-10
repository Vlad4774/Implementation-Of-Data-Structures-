
using System.IO.Compression;
using System.Security.Cryptography;

namespace WorkWithStream
{
    public class StreamWriteAndRead
    {
        private MemoryStream stream;
        private bool encrypted;
        private bool compressed;
        private Aes aes;

        public StreamWriteAndRead(MemoryStream newStream, bool encrypt, bool compress)
        {
            this.stream = newStream;
            this.encrypted = encrypt;
            this.compressed = compress;
            this.aes = Aes.Create();
        }

        public void Write(string text)
        {
            Stream outputStream = stream;

            if (compressed)
            {
                outputStream = new GZipStream(outputStream, CompressionMode.Compress);
            }

            if (encrypted)
            {
                ICryptoTransform encryptor = this.aes.CreateEncryptor();
                outputStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write);
            }

            StreamWriter writer = new StreamWriter(outputStream);
            writer.WriteLine(text);
            writer.Flush();
            if (outputStream is CryptoStream cryptoStream)
            {
                cryptoStream.FlushFinalBlock();
            }
        }

        public string Read()
        {
            stream.Position = 0;

            Stream inputStream = stream;
            if (compressed)
            {
                inputStream = new GZipStream(inputStream, CompressionMode.Decompress);
            }

            if (encrypted)
            {
                ICryptoTransform decryptor = this.aes.CreateDecryptor();
                inputStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read);
            }

            StreamReader reader = new StreamReader(inputStream);
            return reader.ReadToEnd();
        }
    }

}