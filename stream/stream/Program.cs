
using System;
using System.IO;

namespace ConsoleApplication
{
    class Write
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\vladb\\OneDrive\\Documente\\file.txt"))
            {
                writer.WriteLine("Am reusit");
            }
        }
    }
}
