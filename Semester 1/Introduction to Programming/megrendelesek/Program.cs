using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        struct Offer
        {
            public int company;
            public int product;
            public int price;
        }

        static int nCompanies;
        static int nProducts;
        static int nOffers;
        static Offer[]? offers;

        public static void Main(String[] args)
        {
            input();

            feladat1();
            feladat2();
        }

        static void input()
        {
            String[] splitLine = Console.ReadLine().Split(" ");
            nCompanies = Convert.ToInt32(splitLine[0]);
            nProducts = Convert.ToInt32(splitLine[1]);
            nOffers = Convert.ToInt32(splitLine[2]);
            offers = new Offer[nOffers];

            for (int i = 0; i < nOffers; i++)
            {
                splitLine = Console.ReadLine().Split(" ");
                offers[i].company = Convert.ToInt32(splitLine[0]);
                offers[i].product = Convert.ToInt32(splitLine[1]);
                offers[i].price = Convert.ToInt32(splitLine[2]);
            }
        }

        static void feladat1()
        {
            Console.WriteLine("#");

            int maxProduct = offers[0].product;
            int maxPrice = offers[0].price;

            for (int i = 1; i < nOffers; i++)
            {
                if (offers[i].price > maxPrice || (offers[i].price == maxPrice && offers[i].product < maxProduct))
                {
                    maxPrice = offers[i].price;
                    maxProduct = offers[i].product;
                }
            }

            Console.WriteLine(maxProduct);
        }

        static void feladat2()
        {
            Console.WriteLine("#");

            Dictionary<int, HashSet<int>> productCount = new Dictionary<int, HashSet<int>>();

            int maxCount = 0;
            int maxCompany = offers[0].company;
            for (int i = 0; i < nOffers; i++)
            {
                productCount[offers[i].company].Add(offers[i].product);
                if (productCount[offers[i].company].Count > maxCount)
                {
                    maxCompany = offers[i].company;
                    maxCount = productCount[offers[i].company].Count;
                }

                if (productCount[offers[i].company].Count == maxCount && offers[i].company < maxCompany)
                {
                    maxCompany = offers[i].company;
                    maxCount = productCount[offers[i].company].Count;
                }
            }

            Console.WriteLine(maxCompany);
        }
    }
}