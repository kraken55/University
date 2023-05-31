using System;

namespace HelloWorld
{
    class Program
    {
        struct Entry
        {
            public int studentID;
            public int languageID;
            public int grade;
        }

        static int nEntries;
        static int nStudents;
        static int nLanguages;
        static Entry[]? entries;

        static void Main(string[] args)
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
            nEntries = Convert.ToInt32(splitLine[0]);
            entries = new Entry[nEntries];
            nStudents = Convert.ToInt32(splitLine[1]);
            nLanguages = Convert.ToInt32(splitLine[2]);

            for (int i = 0; i < nEntries; i++)
            {
                splitLine = Console.ReadLine().Split(" ");
                entries[i].studentID = Convert.ToInt32(splitLine[0]);
                entries[i].languageID = Convert.ToInt32(splitLine[1]);
                entries[i].grade = Convert.ToInt32(splitLine[2]);
            }
        }

        static void feladat1()
        {
            int maxGradeInd = 0;
            for (int i = 1; i < nEntries; i++)
            {
                if (entries[i].grade > entries[maxGradeInd].grade)
                {
                    maxGradeInd = i;
                }
            }
            Console.WriteLine(entries[maxGradeInd].studentID + " " + entries[maxGradeInd].languageID);
        }

        static void feladat2()
        {
            int[] languageCounts = new int[nLanguages];
            for (int i = 0; i < nLanguages; i++)
            {
                languageCounts[i] = 0;
            }

            int currMax = 0;
            int currMaxInd = 0;
            for (int i = 0; i < nEntries; i++)
            {
                int langInd = entries[i].languageID - 1;
                languageCounts[langInd]++;
                if (languageCounts[langInd] > currMax)
                {
                    currMax = languageCounts[langInd];
                    currMaxInd = langInd;
                }
            }
            Console.WriteLine(currMaxInd + 1);
        }

        static void feladat3()
        {
            int[] languageCounts = new int[nLanguages];
            for (int i = 0; i < nLanguages; i++)
            {
                languageCounts[i] = 0;
            }

            int count = nLanguages;
            for (int i = 0; i < nEntries; i++)
            {
                if (languageCounts[entries[i].languageID - 1] == 0)
                {
                    count--;
                }
                languageCounts[entries[i].languageID - 1]++;
            }

            Console.Write(count);
            for (int i = 0; i < nLanguages; i++)
            {
                if (languageCounts[i] == 0)
                {
                    Console.Write(" " + (i + 1));
                }
            }
            Console.WriteLine();
        }

        static void feladat4()
        {
            bool[] isGoodStudent = new bool[nStudents];
            for (int i = 0; i < nStudents; i++)
            {
                isGoodStudent[i] = true;
            }

            for (int i = 0; i < nEntries; i++)
            {
                if (entries[i].grade < 90)
                {
                    isGoodStudent[entries[i].studentID - 1] = false;
                }
            }

            int ind = 0;
            while (ind < nStudents && isGoodStudent[ind] == false)
            {
                ind++;
            }

            if (ind < nStudents)
            {
                Console.WriteLine(ind + 1);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        static void feladat5()
        {
            bool[] isGoodStudent = new bool[nStudents];
            for (int i = 0; i < nStudents; i++)
            {
                isGoodStudent[i] = false;
            }

            int count = 0;
            for (int i = 0; i < nEntries; i++)
            {
                if (entries[i].grade == 100 && isGoodStudent[entries[i].studentID - 1] == false)
                {
                    isGoodStudent[entries[i].studentID - 1] = true;
                    count++;
                }
            }

            Console.Write(count);
            for (int i = 0; i < nStudents; i++)
            {
                if (isGoodStudent[i] == true)
                {
                    Console.Write(" " + (i + 1));
                }
            }
            Console.WriteLine();
        }
    }
}
