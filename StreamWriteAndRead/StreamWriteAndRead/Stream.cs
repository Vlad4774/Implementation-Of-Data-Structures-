
namespace StreamWriteAndRead
{
    class stream
    {
        public string WriteAndRead(string text, string filePath)
        {
            using (Stream stream = new FileStream((filePath), FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(text);
                }
            }

            using (Stream stream = new FileStream((filePath), FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

