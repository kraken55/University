using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static int nDays;
        static int nTornados;
        static int[] tornados;

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

            nDays = Convert.ToInt32(splitLine[0]);
            nTornados = Convert.ToInt32(splitLine[1]);

            tornados = new int[nTornados];
            for (int i = 0; i < nTornados; i++)
            {
                tornados[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void feladat1()
        {
            Console.WriteLine("#");

            HashSet<int> uniqueDays = new HashSet<int>(tornados);

            Console.WriteLine(nDays - uniqueDays.Count);
        }

        static void feladat2()
        {
            Console.WriteLine("#");

            for (int i = 1; i < nTornados - 1; i++)
            {
                if (tornados[i - 1] == tornados[i] - 1 && tornados[i + 1] == tornados[i] + 1)
                {
                    if (i >= 2 && tornados[i - 2] == tornados[i - 1])
                    {
                        continue;
                    }
                    if (i <= nTornados - 3 && tornados[i + 1] == tornados[i + 2])
                    {
                        continue;
                    }

                    Console.WriteLine(tornados[i]);
                    return;
                }
            }

            Console.WriteLine("0");
        }

        static void feladat3()
        {
            Console.WriteLine("#");

            int maxLen = 0;
            for (int i = 0; i < nTornados - 1; i++)
            {
                int currLen = tornados[i + 1] - tornados[i] - 1;
                if (currLen > maxLen)
                {
                    maxLen = currLen;
                }
            }

            int beforeFirstDayLen = tornados[0] - 1;
            int afterLastDayLen = nDays - tornados[nTornados - 1];
            if (beforeFirstDayLen > maxLen)
            {
                maxLen = beforeFirstDayLen;
            }
            if (afterLastDayLen > maxLen)
            {
                maxLen = afterLastDayLen;
            }

            Console.WriteLine(maxLen);
        }

        /*
        static void feladat4()
        {
            Console.WriteLine("#");

            int maxCount = 0;

            int currCount = 1;
            for (int i = 0; i < nTornados - 1; i++)
            {
                if (tornados[i] == tornados[i + 1])
                {
                    currCount++;
                }
                else
                {
                    if (currCount > maxCount)
                    {
                        maxCount = currCount;
                    }
                    currCount = 1;
                }
            }

            Console.WriteLine(maxCount);
        }
        */

        static void feladat4()
        {
            Console.WriteLine("#");

            Dictionary<int, int> tornadosPerDay = new Dictionary<int, int>();

            for (int i = 1; i <= nDays; i++)
            {
                tornadosPerDay[i] = 0;
            }

            for (int i = 0; i < nTornados; i++)
            {
                tornadosPerDay[tornados[i]]++;
            }

            int maxValue = 0;
            for (int i = 1; i <= nDays; i++)
            {
                if (tornadosPerDay[i] > maxValue)
                {
                    maxValue = tornadosPerDay[i];
                }
            }

            Console.WriteLine(maxValue);
        }

        /*
        static void feladat5()
        {
            Console.WriteLine("#");

            int startDay = 1;
            int endDay = 1;
            int maxLen = 0;

            int currLen = 1;
            int offset = 0;
            for (int i = 0; i < nTornados - 1; i++)
            {
                if (tornados[i] == tornados[i + 1] - 1)
                {
                    currLen++;
                }
                else if (tornados[i] == tornados[i + 1])
                {
                    offset++;
                    continue;
                }
                else
                {
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        endDay = tornados[i];
                        startDay = tornados[i + 1 - currLen - offset];
                    }
                    currLen = 1;
                    offset = 0;
                }
            }

            Console.WriteLine($"{startDay} {endDay}");
        }
        */

        static void feladat5()
        {
            Console.WriteLine("#");

            int startDay = 1;
            int endDay = 1;
            int maxLen = 0;

            int currLen = 1;
            int nSame = 0;
            for (int i = 0; i < nTornados - 1; i++)
            {
                if (tornados[i] == tornados[i + 1])
                {
                    nSame++;
                    continue;
                }

                if (tornados[i] + 1 == tornados[i + 1])
                {
                    currLen++;
                }
                else
                {
                    if (currLen > maxLen)
                    {
                        maxLen = currLen;
                        endDay = tornados[i];
                        startDay = tornados[i + 1 - currLen - nSame];
                    }
                    currLen = 1;
                    nSame = 0;
                }
            }

            if (currLen > maxLen)
            {
                Console.WriteLine($"{tornados[nTornados - currLen - nSame]} {tornados[nTornados - 1]}");
            }
            else
            {
                Console.WriteLine($"{startDay} {endDay}");
            }
        }
    }
}