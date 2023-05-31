using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        struct Candy
        {
            public int company;
            public int flavour;
            public int price;
        }

        static int n;
        static int nCompanies;
        static int nFlavours;
        static Candy[] candies;

        public static void Main(String[] args)
        {
            init();
            feladat1();
            feladat2();
            feladat3();
            feladat4();
            feladat5();
        }

        static void init()
        {
            String[] splitLine = Console.ReadLine().Split(" ");
            n = Convert.ToInt32(splitLine[0]);
            nCompanies = Convert.ToInt32(splitLine[1]);
            nFlavours = Convert.ToInt32(splitLine[2]);
            candies = new Candy[n];

            for (int i = 0; i < n; i++)
            {
                splitLine = Console.ReadLine().Split(" ");
                candies[i].company = Convert.ToInt32(splitLine[0]);
                candies[i].flavour = Convert.ToInt32(splitLine[1]);
                candies[i].price = Convert.ToInt32(splitLine[2]);
            }
        }

        static void feladat1()
        {
            int minPrice = Int32.MaxValue;
            int minCompany = 0;
            int minFlavour = 0;

            for (int i = 0; i < n; i++)
            {
                if (candies[i].price < minPrice)
                {
                    minPrice = candies[i].price;
                    minCompany = candies[i].company;
                    minFlavour = candies[i].flavour;
                }
            }

            Console.WriteLine($"{minCompany} {minFlavour}");
        }

        static void feladat2()
        {
            Dictionary<int, int> flavourPerCompany = new Dictionary<int, int>();
            for (int i = 1; i <= nCompanies; i++)
            {
                flavourPerCompany[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                flavourPerCompany[candies[i].company]++;
            }

            int maxCompany = 1;
            int maxValue = 0;
            for (int i = 1; i <= nCompanies; i++)
            {
                if (flavourPerCompany[i] > maxValue)
                {
                    maxValue = flavourPerCompany[i];
                    maxCompany = i;
                }
            }

            Console.WriteLine(maxCompany);
        }

        static void feladat3()
        {
            Dictionary<int, int> mostExpensivePerCompany = new Dictionary<int, int>();
            for (int i = 1; i <= nCompanies; i++)
            {
                mostExpensivePerCompany[i] = 0;
            }

            int companyCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (mostExpensivePerCompany[candies[i].company] == 0)
                {
                    companyCount++;
                }
                if (candies[i].price > mostExpensivePerCompany[candies[i].company])
                {
                    mostExpensivePerCompany[candies[i].company] = candies[i].price;
                }
            }

            Console.Write(companyCount + " ");
            for (int i = 1; i <= nCompanies; i++)
            {
                if (mostExpensivePerCompany[i] != 0)
                {
                    Console.Write(i + " " + mostExpensivePerCompany[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void feladat4()
        {
            HashSet<int> uniqueCandies = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                uniqueCandies.Add(candies[i].flavour);
            }

            Console.WriteLine(uniqueCandies.Count);
        }

        static void feladat5()
        {
            int[] uniqueCandies = new int[nFlavours];
            for (int i = 0; i < nFlavours; i++)
            {
                uniqueCandies[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                uniqueCandies[candies[i].flavour - 1]++;
            }

            int count = 0;
            for (int i = 0; i < nFlavours; i++)
            {
                if (uniqueCandies[i] == 1)
                {
                    count++;
                }
            }
            Console.Write(count + " ");

            for (int i = 0; i < nFlavours; i++)
            {
                if (uniqueCandies[i] == 1)
                {
                    Console.Write(i + 1 + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
