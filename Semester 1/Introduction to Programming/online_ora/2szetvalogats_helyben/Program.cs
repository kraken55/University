using System;

namespace Program
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] temps = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                temps[i] = rand.Next(-15, 25);
            }

            /*********************************************************/

            int startInd = 0;
            int endInd = n - 1;
            int firstElem = temps[startInd];
            int count = 0;
            
            bool exists = false;
            while (startInd < endInd)
            {
                while (startInd < endInd && temps[endInd] >= 0)
                {
                    endInd--;
                }
                exists = startInd < endInd;

                if (exists)
                {
                    temps[startInd] = temps[endInd];
                    startInd++;
                    while (startInd < endInd && temps[startInd] < 0)
                    {
                        startInd++;
                    }
                    exists = startInd < endInd;

                    if (exists)
                    {
                        temps[endInd] = temps[startInd];
                        endInd--;
                    }
                }
            }
            temps[startInd] = firstElem;
            if (firstElem < 0)
            {
                count = startInd;
            }
            else
            {
                count = startInd - 1;
            }

            /*********************************************************/

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(temps[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
