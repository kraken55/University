using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        struct Entry
        {
            public string name;
            public int sport;
        }
        static Entry[]? entries;

        static int nSports;
        static int nEntries;

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
            nSports = Convert.ToInt32(splitLine[0]);
            nEntries = Convert.ToInt32(splitLine[1]);
            entries = new Entry[nEntries];

            for (int i = 0; i < nEntries; i++)
            {
                splitLine = Console.ReadLine().Split(" ");
                entries[i].name = splitLine[0];
                entries[i].sport = Convert.ToInt32(splitLine[1]);
            }
        }

        static void feladat1()
        {
            Console.WriteLine("#");

            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i < nEntries; i++)
            {
                if (!counts.ContainsKey(entries[i].name))
                {
                    counts[entries[i].name] = 1;
                }
                else
                {
                    counts[entries[i].name]++;
                }
            }

            foreach (string name in counts.Keys)
            {
                if (counts[name] == 1)
                {
                    Console.WriteLine(name);
                    return;
                }
            }
            Console.WriteLine();
        }

        static void feladat2()
        {
            Console.WriteLine("#");

            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i < nEntries; i++)
            {
                if (!counts.ContainsKey(entries[i].name))
                {
                    counts[entries[i].name] = 1;
                }
                else
                {
                    counts[entries[i].name]++;
                }
            }

            string maxName = "";
            int max = 0;
            foreach (string name in counts.Keys)
            {
                if (counts[name] > max)
                {
                    max = counts[name];
                    maxName = name;
                }
            }
            Console.WriteLine(maxName);
        }

        static void feladat3()
        {
            Console.WriteLine("#");

            int[] sportsCount = new int[nSports];

            for (int i = 0; i < nEntries; i++)
            {
                sportsCount[entries[i].sport - 1]++;
            }

            for (int i = 0; i < nSports; i++)
            {
                Console.Write(sportsCount[i] + " ");
            }
            Console.WriteLine();
        }

        static void feladat4()
        {
            Console.WriteLine("#");

            HashSet<string>[] entriesBySports = new HashSet<string>[nSports];
            for (int i = 0; i < nSports; i++)
            {
                entriesBySports[i] = new HashSet<string>();
            }

            for (int i = 0; i < nEntries; i++)
            {
                entriesBySports[entries[i].sport - 1].Add(entries[i].name);
            }

            for (int i = 0; i < nSports; i++)
            {
                if (entriesBySports[i].Count == 0)
                {
                    continue;
                }
                for (int j = i + 1; j < nSports; j++)
                {
                    if (entriesBySports[j].Count == 0)
                    {
                        continue;
                    }

                    if (entriesBySports[j].Overlaps(entriesBySports[i]) == false)
                    {
                        Console.WriteLine($"{i + 1} {j + 1}");
                    }
                }
            }
        }

        static void feladat5()
        {
            Console.WriteLine("#");

            HashSet<string> names = new HashSet<string>();
            Dictionary<int, HashSet<string>> namesBySport = new Dictionary<int, HashSet<string>>();
            for (int i = 0; i < nSports; i++)
            {
                namesBySport[i] = new HashSet<string>();
            }

            for (int i = 0; i < nEntries; i++)
            {
                if (!names.Contains(entries[i].name))
                {
                    names.Add(entries[i].name);
                }
                namesBySport[entries[i].sport - 1].Add(entries[i].name);
            }

            foreach (string name in names)
            {
                HashSet<string> uniqueNames = new HashSet<string>();
                for (int i = 0; i < nSports; i++)
                {
                    if (!namesBySport[i].Contains(name))
                    {
                        continue;
                    }
                    foreach (string peerName in namesBySport[i])
                    {
                        if (peerName != name && !uniqueNames.Contains(peerName))
                        {
                            uniqueNames.Add(peerName);
                        }
                    }
                }
                Console.WriteLine($"{name} {uniqueNames.Count}");
            }
        }
    }
}
