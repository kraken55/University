using System;
using System.Collections.Generic;

namespace Program
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] temp = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                temp[i] = rand.Next(-15, 25);
            }

            /*********************************************************/

            int[] neg = new int[n];
            int[] pos = new int[n];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (temp[i] < 0)
                {
                    neg[count] = temp[i];
                    count++;
                }
                else
                {
                    pos[i - count] = temp[i];
                }
            }

            /*********************************************************/

            for (int i = 0; i < n; i++)
            {
                Console.Write(temp[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write(neg[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < n - count; i++)
            {
                Console.Write(pos[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}