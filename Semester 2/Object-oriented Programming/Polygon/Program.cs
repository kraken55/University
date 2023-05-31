using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using TextFile;

namespace Polygon
{
    class Program
    {
        static void Main(String[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string filename = "input.txt";
            TextFileReader reader = new TextFileReader(filename);

            reader.ReadDouble(out double x);
            reader.ReadDouble(out double y);
            Point e = new Point(x, y);

            List<Polygon> container = new List<Polygon>();
            while (reader.ReadInt(out int sides))
            {
                try
                {
                    container.Add(Polygon.Create(reader, sides));
                }
                catch (Polygon.FewVerticesException)
                {
                    Console.WriteLine("A polygon needs more than two vertices.");
                    reader.ReadLine(out string line);
                }
            }

            foreach (Polygon p in container)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"original polygon: {p}");
                Console.WriteLine($"centroid of the original polygon: {p.Centroid()}");
                p.Shift(e);
                Console.WriteLine($"shifted polygon: {p}");
                Console.WriteLine($"centroid of the shifted polygon: {p.Centroid()}");
            }
        }
    }
}