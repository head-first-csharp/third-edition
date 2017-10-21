using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseABinaryWriter
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            int intValue = 48769414;
            string stringValue = "Hello!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695F;
            char charValue = 'E';

            using (FileStream output = File.Create("binarydata.dat"))
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);
            }

            byte[] dataWritten = File.ReadAllBytes("binarydata.dat");
            foreach (byte b in dataWritten)
                Console.Write("{0:x2} ", b);
            Console.WriteLine(" - {0} bytes", dataWritten.Length);
            Console.ReadKey();

            using (FileStream input = File.OpenRead("binarydata.dat"))
            using (BinaryReader reader = new BinaryReader(input))
            {
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.Write("int: {0}  string: {1}  bytes: ", intRead, stringRead);
                foreach (byte b in byteArrayRead)
                    Console.Write("{0} ", b);
                Console.Write(" float: {0}  char: {1} ", floatRead, charRead);
            }
            Console.ReadKey();

        }
    }
}