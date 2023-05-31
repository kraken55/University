using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        struct Person
        {
            public int age;
            public int salary;
        }

        static int nPeople = Convert.ToInt32(Console.ReadLine());
        static Person[] People = new Person[nPeople];

        public static void Main(string[] args)
        {
            for (int i = 0; i < nPeople; i++)
            {
                String[] splitLine = Console.ReadLine().Split(' ');
                People[i].age = Convert.ToInt32(splitLine[0]);
                People[i].salary = Convert.ToInt32(splitLine[1]);
            }

            feladat1();
            feladat2();
            feladat3();
            feladat4();
        }

        static void feladat1()
        {
            int maxAge = People[0].age;
            int maxAgeIndex = 0;
            for (int i = 1; i < nPeople; i++)
            {
                if (People[i].age > maxAge)
                {
                    maxAge = People[i].age;
                    maxAgeIndex = i;
                }
            }

            Console.WriteLine(maxAgeIndex + 1);
        }

        static void feladat2()
        {
            int count = 0;
            for (int i = 0; i < nPeople; i++)
            {
                if (People[i].age > 40 && People[i].salary < 200_000)
                {
                    count++;
                }
            }
            
            Console.WriteLine(count);
        }

        static void feladat3()
        {
            HashSet<int> ages = new HashSet<int>();

            for (int i = 0; i < nPeople; i++)
            {
                if (!ages.Contains(People[i].age))
                {
                    ages.Add(People[i].age);
                }
            }

            Console.WriteLine(ages.Count);
        }

        static void feladat4()
        {
            List<int> youngerThan30Indices = new List<int>();

            for (int i = 0; i < nPeople; i++)
            {
                if (People[i].age < 30)
                {
                    youngerThan30Indices.Add(i + 1);
                }
            }

            Console.Write(youngerThan30Indices.Count);
            foreach (int elem in youngerThan30Indices)
            {
                Console.Write(" " + elem);
            }
        }
    }
}
