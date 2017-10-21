using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexDumperUsingStreamReader
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"c:\files\inputFile.txt"))
            using (StreamWriter writer = new StreamWriter(@"c:\files\outputFile.txt", false))
            {
                int position = 0;
                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[16];
                    int charactersRead = reader.ReadBlock(buffer, 0, 16);
                    writer.Write("{0}: ", String.Format("{0:x4}", position));
                    position += charactersRead;
                    for (int i = 0; i < 16; i++)
                    {
                        if (i < charactersRead)
                        {
                            string hex = String.Format("{0:x2}", (byte)buffer[i]);
                            writer.Write(hex + " ");
                        }
                        else
                            writer.Write("   ");
                        if (i == 7) { writer.Write("-- "); }
                        if (buffer[i] < 32 || buffer[i] > 250) { buffer[i] = '.'; }
                    }
                    string bufferContents = new string(buffer);
                    writer.WriteLine("   " + bufferContents.Substring(0, charactersRead));
                }
            }
        }
    }
}
