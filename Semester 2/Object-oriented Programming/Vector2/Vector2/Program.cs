using System;
using TextFile;

namespace Vector2
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");

            Vector2[] vectorArr;
            reader.ReadInt(out int nVectors);
            vectorArr = new Vector2[nVectors];

            for (int i = 0; i < nVectors; i++)
            {
                reader.ReadInt(out int x);
                reader.ReadInt(out int y);
                vectorArr[i] = new Vector2(x, y);
            }

            Vector2 sumVectors = new Vector2(0, 0);
            for (int i = 0; i < nVectors; i++)
            {
                sumVectors += vectorArr[i];
            }

            if (sumVectors.isPerpendicularTo(vectorArr[0]))
            {
                System.Console.WriteLine("yes");
            }
            else
            {
                System.Console.WriteLine("no");
            }
        }
    }
}