using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        struct House
        {
            public int floorArea;
            public int price;
        }

        static int nHouses = Convert.ToInt32(Console.ReadLine());
        static House[] Houses = new House[nHouses];

        public static void Main(String[] args)
        {
            for (int i = 0; i < nHouses; i++)
            {
                String[] splitLine = Console.ReadLine().Split(" ");
                Houses[i].floorArea = Convert.ToInt32(splitLine[0]);
                Houses[i].price = Convert.ToInt32(splitLine[1]);
            }

            feladat1();
            feladat2();
            feladat3();
            feladat4();
        }

        static void feladat1()
        {
            int maxPrice = Houses[0].price;
            int maxPriceIndex = 0;
            for (int i = 0; i < nHouses; i++)
            {
                if (Houses[i].price > maxPrice)
                {
                    maxPrice = Houses[i].price;
                    maxPriceIndex = i;
                }
            }

            Console.WriteLine(maxPriceIndex + 1);
        }

        static void feladat2()
        {
            int count = 0;
            for (int i = 0; i < nHouses; i++)
            {
                if (Houses[i].floorArea > 100 && Houses[i].price < 40)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static void feladat3()
        {
            HashSet<int> floorAreaSet = new HashSet<int>();

            for (int i = 0; i < nHouses; i++)
            {
                if (!floorAreaSet.Contains(Houses[i].floorArea))
                {
                    floorAreaSet.Add(Houses[i].floorArea);
                }
            }

            Console.WriteLine(floorAreaSet.Count);
        }

        static void feladat4()
        {
            List<int> ls = new List<int>();

            for (int i = 0; i < nHouses; i++)
            {
                if (Houses[i].price > 100)
                {
                    ls.Add(i + 1);
                }
            }

            Console.Write(ls.Count);
            foreach (int elem in ls)
            {
                Console.Write(" " + elem);
            }
        }
    }
}