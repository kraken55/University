using System;
using System.Collections.Generic;
using TextFile;

namespace Cactus
{
    internal class Program
    {
        struct Cactus
        {
            public string species { get; }
            public string origin { get; }
            public string colour { get; }
            public int size { get; }

            public Cactus(string species, string origin, string colour, int size)
            {
                this.species = species;
                this.origin = origin;
                this.colour = colour;
                this.size = size;
            }

            public override string ToString()
            {
                return $"[{this.species}, {this.origin}, {this.colour}, {this.size}]";
            }
        }

        static bool ReadCactus(TextFileReader reader, out Cactus cactus)
        {
            bool isNotEmpty = reader.ReadLine(out string line);

            if (!isNotEmpty)
            {
                cactus = new Cactus("", "", "", 0);
                return false;
            }

            string[] splitLine = line.Split(" ");
            cactus = new Cactus(splitLine[0], splitLine[1], splitLine[2], Convert.ToInt32(splitLine[3]));
            return true;
        }

        static bool existsRed(TextFileReader reader)
        {
            Cactus c;
            while (ReadCactus(reader, out c))
            {
                if (c.colour == "piros")
                {
                    return true;
                }
            }

            return false;
        }

        static void mexican_red(TextFileReader reader, out List<Cactus> mexican, out List<Cactus> red)
        {
            mexican = new List<Cactus>();
            red = new List<Cactus>();

            Cactus c;
            while (ReadCactus(reader, out c))
            {
                if (c.origin == "mexico")
                {
                    mexican.Add(c);
                }

                if (c.colour == "piros")
                {
                    red.Add(c);
                }
            }
        }

        static string getMaxSizeSpecies(TextFileReader reader)
        {
            Cactus c;
            Cactus maxCactus = new Cactus("", "", "", 0);
            while (ReadCactus(reader, out c))
            {
                if (c.size > maxCactus.size)
                {
                    maxCactus = c;
                }
            }

            return c.species;
        }

        public static void Main(String[] args)
        {
            const string filename = "input.txt";

            Console.WriteLine(existsRed(new TextFileReader(filename)));

            List<Cactus> mexican;
            List<Cactus> red;
            mexican_red(new TextFileReader(filename), out mexican, out red);
            mexican.ForEach(k => Console.Write($"{k}\t"));
            red.ForEach(k => Console.Write($"{k}\t"));
            Console.WriteLine(getMaxSizeSpecies(new TextFileReader(filename)));
            
        }
    }
}