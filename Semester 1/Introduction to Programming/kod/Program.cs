using System;

namespace Program
{  
    class Program
    {
        public static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            } 

            int ind = 0;
            bool isPositive = true;
            for (int i = 0; i < n && isPositive; i++)
            {
                if (arr[i] < 0)
                {
                    isPositive = false;
                    ind = i;
                }
            }

            if (isPositive == true)
            {
                Console.WriteLine("Nincs ilyen.");
            }
            else
            {
                Console.WriteLine(ind);
            }
        }
    }
}