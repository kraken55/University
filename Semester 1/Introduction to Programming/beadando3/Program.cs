using System;

namespace Program
{
    class Program
    {
        struct Stop
        {
            public string arrive;
            public string depart;
        }

        public static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Stop[] stops = new Stop[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    stops[i].arrive = "";
                    stops[i].depart = Console.ReadLine();
                }
                else if (i == n - 1)
                {
                    stops[i].arrive = Console.ReadLine();
                    stops[i].depart = "";
                }
                else
                {
                    stops[i].arrive = Console.ReadLine();
                    stops[i].depart = Console.ReadLine();
                }
            }

            int start = 0;
            int end = 0;
            int[] maxInd = {0, 0};
            for (int i = 0; i < n; i++)
            {
                if (stops[i].arrive == stops[i].depart)
                {
                    end = i + 1;
                }
                else
                {
                    if ((maxInd[1] - maxInd[0]) < (end - start))
                    {
                        maxInd[0] = start;
                        maxInd[1] = end;
                    }
                    start = i;
                    end = i;
                }
            }

            if (maxInd[0] == 0 && maxInd[1] == 0)
            {
                Console.WriteLine("0 0");
            }
            else
            {
                Console.WriteLine($"{maxInd[0] + 1} {maxInd[1] + 1}");
            }
        }
    }
}