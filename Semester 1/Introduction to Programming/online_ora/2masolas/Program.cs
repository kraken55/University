using System;

namespace Program
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-100, 150);
            }

            /*********************************************************/

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }

            /*********************************************************/

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}