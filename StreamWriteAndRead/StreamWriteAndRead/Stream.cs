
using System.IO.Compression;
using System.Security.Cryptography;

namespace WorkWithStream
{
    public class StreamWriteAndRead
    {
        private MemoryStream stream;
        private bool encrypted;
        private bool compressed;
        private byte[] key;
        private byte[] iv;

        public StreamWriteAndRead(MemoryStream newStream, bool encrypt, bool compress)
        {
            this.stream = newStream;
            this.encrypted = encrypt;
            this.compressed = compress;
            this.key = GenerateKeyOrIv(32);
            this.iv = GenerateKeyOrIv(16);
        }

        public void Write(string text)
        {
            Stream outputStream = stream;
            if (encrypted)
            {
                Aes aes = Aes.Create();
                ICryptoTransform encryptor = aes.CreateEncryptor(this.key, this.iv);
                outputStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
            }

            if (compressed)
            {
                outputStream = new GZipStream(outputStream, CompressionMode.Compress);
            }

            StreamWriter writer = new StreamWriter(outputStream);
            writer.WriteLine(text);
            writer.Flush();
            stream.Position = 0;
        }

        public string Read()
        {
            stream.Position = 0;

            Stream inputStream = stream;
            if (this.compressed)
            {
                inputStream = new GZipStream(stream, CompressionMode.Decompress);
            }

            if (this.encrypted)
            {
                Aes aes = Aes.Create();
                ICryptoTransform decryptor = aes.CreateDecryptor(this.key, this.iv);
                inputStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read);
            }

            StreamReader reader = new StreamReader(inputStream);
            return reader.ReadToEnd();
        }

        private byte[] GenerateKeyOrIv(int size)
        {
            byte[] array = new byte[size];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(array);
            return array;
        }
    }
}
