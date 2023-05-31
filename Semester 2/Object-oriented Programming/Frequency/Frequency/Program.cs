using System;
using TextFile;

namespace Frequency
{
    class Program
    {
        static void Main()
        {
            try
            {
                string filename = "input25.txt";
                TextFileReader reader = new(filename);

                reader.ReadInt(out int m);

                Bag bag = new(m);

                while (reader.ReadInt(out int e))
                {
                    try
                    {
                        bag.PutIn(e);
                    }
                    catch (Bag.IllegalElementException)
                    {
                        Console.WriteLine($"The element to be added must be in the interval [0..{m}].");
                    }
                }

                Console.WriteLine($"The most frequent element: {bag.MostFrequent()}");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist.");
            }
            catch (Bag.NegativeSizeException)
            {
                Console.WriteLine("The upper limit of the input numbers cannot be negative.");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("There is no most frequent element (i.e. the bag is empty).");
            }
        }
    }
}