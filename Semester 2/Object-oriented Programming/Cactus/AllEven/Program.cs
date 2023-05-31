using System;
using TextFile;

namespace AllEven
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine(isAllEven());
        }

        static bool isAllEven()
        {
            TextFileReader reader = new TextFileReader("numberinput.txt");
            
            while (reader.ReadInt(out int n))
            {
                if (n % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}