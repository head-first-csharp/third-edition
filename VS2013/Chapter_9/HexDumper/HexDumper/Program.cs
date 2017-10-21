using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexDumper
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("usage: HexDumper file-to-dump");
                System.Environment.Exit(1);
            }
            if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("File does not exist: {0}", args[0]);
                System.Environment.Exit(2);
            }
            using (Stream input = File.OpenRead(args[0]))
            {
                int position = 0;
                byte[] buffer = new byte[16];
                while (position < input.Length)
                {
                    int charactersRead = input.Read(buffer, 0, buffer.Length);
                    if (charactersRead > 0)
                    {
                        Console.Write("{0}: ", String.Format("{0:x4}", position));
                        position += charactersRead;

                        for (int i = 0; i < 16; i++)
                        {
                            if (i < charactersRead)
                            {
                                string hex = String.Format("{0:x2}", (byte)buffer[i]);
                                Console.Write(hex + " ");
                            }
                            else
                                Console.Write("   ");

                            if (i == 7)
                                Console.Write("-- ");

                            if (buffer[i] < 32 || buffer[i] > 250) { buffer[i] = (byte)'.'; }
                        }
                        string bufferContents = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine("   " + bufferContents);
                    }
                }
            }
        }
    }
}
