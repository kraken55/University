using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static int[] temps = {7, 5, -2, 0, -4, 3, 3, 3, 4, 4};
        static int n = temps.Length;

        public static void Main(String[] args)
        {
        }

        static void feladat1()
        {
            int maxTemp = temps[0];
            for (int i = 1; i < n; i++)
            {
                if (temps[i] > maxTemp)
                {
                    maxTemp = temps[i];
                }
            }

            Console.WriteLine("Feladat 1");
            Console.WriteLine(maxTemp);
            Console.WriteLine();
        }

        static void feladat2()
        {
            int i = 0;
            while (i < n && temps[i] >= 0)
            {
                i++;
            }


            Console.WriteLine("Feladat 2");
            if (i < n)
            {
                Console.WriteLine("Volt fagy.");
            }
            else
            {
                Console.WriteLine("Nem volt fagy.");
            }
            Console.WriteLine();
        }

        static void feladat3()
        {
            int i = 0;
            while (i < n && temps[i] != 3)
            {
                i++;
            }

            Console.WriteLine("Feladat 3");
            if (i < n)
            {
                Console.WriteLine("Volt 3 fok.");
            } 
            else
            {
                Console.WriteLine("Nem volt 3 fok.");
            }
            Console.WriteLine();
        }

        static void feladat4()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (temps[i] == 0)
                {
                    count++;
                }
            }

            Console.WriteLine("Feladat 4");
            Console.WriteLine(count);
            Console.WriteLine();
        }

        static void feladat5()
        {
            int i = 0;
            while (i < n && temps[i] != 0)
            {
                i++;
            }

            Console.WriteLine("Feladat 5");
            if (i < n)
            {
                Console.WriteLine($"Először az {i + 1}. napon volt 0 fok.");
            }
            else
            {
                Console.WriteLine("Nem volt 0 fok.");
            }
            Console.WriteLine();
        }

        static void feladat6()
        {
            int i = 0;
            while (i < n && temps[i] >= 0)
            {
                i++;
            }

            Console.WriteLine("Feladat 6");
            if (i < n)
            {
                Console.WriteLine($"Az {i + 1}. napon volt először fagy.");
            }
            else
            {
                Console.WriteLine("Nem volt fagy.");
            }
            Console.WriteLine();
        }

        static void feladat7()
        {
            int i = n - 1;
            while (i >= 0 && temps[i] >= 0)
            {
                i--;
            }

            Console.WriteLine("Feladat 7");
            if (i >= 0)
            {
                Console.WriteLine($"Az {i + 1}. napon volt utoljára fagy.");
            }
            else
            {
                Console.WriteLine("Nem volt fagy.");
            }
            Console.WriteLine();
        }

        static void feladat8()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (temps[i] < 0)
                {
                    count++;
                }
            }

            Console.WriteLine("Feladat 8");
            Console.WriteLine(count);
            Console.WriteLine();
        }

        static void feladat9()
        {
            int i = 0;
            while (i < n - 1 && temps[i] != temps[i + 1])
            {
                i++;
            }

            Console.WriteLine("Feladat 9");
            if (i < n - 1)
            {
                Console.WriteLine("Volt, hogy egymás utáni napokon ugyanazt a hőmérsékletet mérték.");
            }
            else
            {
                Console.WriteLine("Nem volt, hogy egymás utáni napokon ugyanazt a hőmérsékletet mérték.");
            }
            Console.WriteLine();
        }

        static void feladat10()
        {
            int i = 1;
            while (i < n && temps[i - 1] >= temps[i])
            {
                i++;
            }

            Console.WriteLine("Feladat 10");
            if (i < n)
            {
                Console.WriteLine($"Az {i + 1}. napon volt először melegebb mint az előző napon.");
            }
            else
            {
                Console.WriteLine("Nem volt ilyen nap.");
            }
            Console.WriteLine();
        }
    }
}