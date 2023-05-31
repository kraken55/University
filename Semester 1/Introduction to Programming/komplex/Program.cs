using System;

namespace Program
{
    internal class Program
    {
        static int nLocations;
        static int nDays;
        struct Entry
        {
            public int locationIndex;
            public double averageTemp;
        }
        static Entry[]? entries;

        public static void Main(String[] args)
        {
            init();
            sortByAvgTemp(0, nLocations - 1);
            printResults();
        }

        static void init()
        {
            // Hibaellenőrzéshez használt segédváltozók
            bool isImproperInput_nLocations = false;
            bool isImproperInput_nDays = false;

            // Települések és napok számának bekérése, hibaellenzőrzéssel
            do
            {
                Console.Write("Települések és napok száma: ");

                string[] splitLine = Console.ReadLine().Split(" ");
                nLocations = Convert.ToInt32(splitLine[0]);
                nDays = Convert.ToInt32(splitLine[1]);
                isImproperInput_nLocations = (nLocations < 1 || nLocations > 1000);
                isImproperInput_nDays = (nDays < 1 || nDays > 1000);

                if (isImproperInput_nLocations)
                {
                    Console.WriteLine("Hibás bemenet! A települések száma 1 és 1000 között kell legyen.");
                    Console.WriteLine("Az ön által megadott adat: " + nLocations);
                    Console.WriteLine("Írja be megfelelően a települések és napok számát!");
                    Console.WriteLine();
                }
                if (isImproperInput_nDays)
                {
                    Console.WriteLine("Hibás bemenet! A napok száma 1 és 1000 között kell legyen.");
                    Console.WriteLine("Az ön által megadott adat: " + nDays);
                    Console.WriteLine("Írja be megfelelően a települések és napok számát!");
                    Console.WriteLine();
                }
            } while (isImproperInput_nLocations || isImproperInput_nDays);

            entries = new Entry[nLocations];

            // Átlaghőmérsékletek kiszámítása, rekordba felvétele
            for (int i = 0; i < nLocations; i++)
            {
                entries[i].locationIndex = i + 1;

                // Hibaellenőrzéshez használt segédváltozó
                bool isImproperInput_dailyTemps = false;

                do
                {
                    Console.WriteLine((i + 1) + " " + ". település hőmérsékleti adatai:");

                    string dailyTemps = Console.ReadLine();
                    entries[i].averageTemp = calculateAvgTemp(dailyTemps, ref isImproperInput_dailyTemps);
                    if (isImproperInput_dailyTemps)
                    {
                        Console.WriteLine("Hibás bement! Minden érték -50 és 50 között kell legyen.");
                        Console.WriteLine("Írja be megfelelően a településhez tartozó értékeket!");
                        Console.WriteLine();
                    }
                } while(isImproperInput_dailyTemps);
            }
        }

        static double calculateAvgTemp(string dailyTemps, ref bool isImproperInput_dailyTemps)
        {
            isImproperInput_dailyTemps = false;

            double avg = 0.0;
            string[] dailyTempsToList = dailyTemps.Split(" ");
            for (int i = 0; i < nDays; i++)
            {
                double currValue = Convert.ToDouble(dailyTempsToList[i]);

                if (currValue < -50 || currValue > 50)
                {
                    isImproperInput_dailyTemps = true;
                    return 0.0;
                }
                avg += currValue;
            }

            return avg / nDays;
        }

        static void sortByAvgTemp(int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                sortByAvgTemp(left, middle);
                sortByAvgTemp(middle + 1, right);

                merge(left, middle, right);
            }
        }

        static void merge(int left, int middle, int right)
        {
            int leftArrayLen = middle - left + 1;
            int rightArrayLen = right - middle;

            Entry[] leftTemp = new Entry[leftArrayLen];
            Entry[] rightTemp = new Entry[rightArrayLen];

            for (int i = 0; i < leftArrayLen; i++)
            {
                leftTemp[i] = entries[left + i];
            }
            for (int i = 0; i < rightArrayLen; i++)
            {
                rightTemp[i] = entries[middle + 1 + i];
            }

            int l = 0, r = 0;
            int k = left;

            while (l < leftArrayLen && r < rightArrayLen)
            {
                if (leftTemp[l].averageTemp == rightTemp[r].averageTemp)
                {
                    if (leftTemp[l].locationIndex > rightTemp[r].locationIndex)
                    {
                        entries[k++] = rightTemp[r++];
                    }
                    else
                    {
                        entries[k++] = leftTemp[l++];
                    }
                }
                else if (leftTemp[l].averageTemp > rightTemp[r].averageTemp)
                {
                    entries[k++] = leftTemp[l++];
                }
                else
                {
                    entries[k++] = rightTemp[r++];
                }
            }

            while (l < leftArrayLen)
            {
                entries[k++] = leftTemp[l++];
            }

            while (r < rightArrayLen)
            {
                entries[k++] = rightTemp[r++];
            }
        }

        static void printResults()
        {
            Console.WriteLine();
            Console.WriteLine("A települések sorszámai, átlaghőmérséklet szerint csökkenő sorrendben:");
            for (int i = 0; i < nLocations; i++)
            {
                Console.Write(entries[i].locationIndex + " ");
            }
            Console.WriteLine();
        }
    }
}
