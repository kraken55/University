using System;

namespace Frequency
{
    public class Bag
    {
        public class NegativeSizeException : Exception { }
        public class EmptyBagException : Exception { }
        public class IllegalElementException : Exception { }

        protected int[] vec;
        protected int max;

        public Bag(int m)
        {
            if (m < 0)
            {
                throw new NegativeSizeException();
            }

            vec = new int[m + 1];
            for (int i = 0; i <= m ; i++)
            {
                vec[i] = 0;
            }
            max = 0;
        }

        public void Erase()
        {
            for (int i = 0; i < vec.Length; i++)
            {
                vec[i] = 0;
            }
            max = 0;
        }

        public void PutIn(int e)
        {
            if (e < 0 || e >= vec.Length)
            {
                throw new IllegalElementException();
            }

            if (++vec[e] > vec[max])
            {
                max = e;
            }
        }

        public int MostFrequent()
        {
            if (vec[max] == 0)
            {
                throw new EmptyBagException();
            }

            return max;
        }
    }
}