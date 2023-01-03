
namespace StreamWriteAndRead
{
    class Stream
    {
        private MemoryStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public Stream()
        {
            stream = new MemoryStream();
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

