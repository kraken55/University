using System;

namespace Program
{
    class Program
    {
        struct Entry
        {
            public int locID;
            public TimeSpan time;
        }

        public static void Main(String[] args)
        {
            String[] inputSpec = Console.ReadLine().Split(" ");
            int nLocations = Convert.ToInt32(inputSpec[0]);
            int nEntries = Convert.ToInt32(inputSpec[1]);
            Entry[] entries = new Entry[nEntries];

            for (int i = 0; i < nEntries; i++)
            {
                String[] splitLine = Console.ReadLine().Split(" ");
                entries[i].locID = Convert.ToInt32(splitLine[0]);
                entries[i].time = new TimeSpan(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]), 0);
            }

            int maxIndex = 0;
            for (int i = 1; i < nEntries - 1; i++)
            {
                if (entries[i + 1].time - entries[i].time > entries[maxIndex + 1].time - entries[maxIndex].time)
                {
                    maxIndex = i;
                }
            }

            Console.Write($"{entries[maxIndex].time.Hours} {entries[maxIndex].time.Minutes} ");
            Console.WriteLine($"{entries[maxIndex + 1].time.Hours} {entries[maxIndex + 1].time.Minutes}");
        }
    }
}
