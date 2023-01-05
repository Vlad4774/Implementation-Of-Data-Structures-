
namespace WorkWithStream
{
    class StreamWriteAndRead
    {
        private MemoryStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public StreamWriteAndRead(MemoryStream newStream)
        {
            this.stream = newStream;
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public void Write(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
            stream.Position = 0;
        }

        public string Read()
        {
            stream.Position = 0;
            return reader.ReadToEnd();
        }
    }
}

