using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeCardsManually
{
    ﻿using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SerializeCardsManually
    {
        using System.IO;
        using System.Runtime.Serialization.Formatters.Binary;

        class Program
        {
            static void Main(string[] args)
            {
                Card threeOfClubs = new Card(Suits.Clubs, Values.Three);
                using (Stream output = File.Create("three-c.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(output, threeOfClubs);
                }

                Card sixOfHearts = new Card(Suits.Hearts, Values.Six);
                using (Stream output = File.Create("six-h.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(output, sixOfHearts);
                }

                byte[] firstFile = File.ReadAllBytes("three-c.dat");
                byte[] secondFile = File.ReadAllBytes("six-h.dat");
                for (int i = 0; i < firstFile.Length; i++)
                    if (firstFile[i] != secondFile[i])
                        Console.WriteLine("Byte #{0}: {1} versus {2}",
                            i, firstFile[i], secondFile[i]);

                firstFile[307] = (byte)Suits.Spades;
                firstFile[364] = (byte)Values.King;
                File.Delete("king-s.dat");
                File.WriteAllBytes("king-s.dat", firstFile);

                using (Stream input = File.OpenRead("king-s.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Card kingOfSpades = (Card)bf.Deserialize(input);
                    Console.WriteLine(kingOfSpades);
                }

                Console.ReadKey();
            }
        }
    }


}
