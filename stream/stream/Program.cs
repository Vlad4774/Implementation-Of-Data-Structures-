
using System;
using System.IO;

namespace ConsoleApplication
{
    class Write
    {
        static void Main(string[] args)
        {
            using (Stream stream = new FileStream(("C:\\Users\\vladb\\OneDrive\\Documente\\file.txt"), FileMode.Open))
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("Am reusit!");

                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
    }
}
