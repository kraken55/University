package myarray.util;

public class ArrayUtil
{
    public static int max(int[] arr)
    {
        int max = arr.length == 0 ? 0 : Integer.MIN_VALUE;
        for (int i = 0; i < arr.length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    public static int max2(int[] arr)
    {
        int max = arr.length == 0 ? 0 : Integer.MIN_VALUE;
        for (int i = 0; i < arr.length; i++)
        {
            max = arr[i] > max ? arr[i] : max;
        }

        return max;
    }

    public static int max3(int[] arr)
    {
        int max = arr.length == 0 ? 0 : Integer.MIN_VALUE;
        for (int i = 0; i < arr.length; i++)
        {
            max = Math.max(max, arr[i]);
        }

        return max;
    }

    public static int max4(int[] arr)
    {
        int max = arr.length == 0 ? 0 : Integer.MIN_VALUE;
        for (int i : arr) 
        {
            if (i > max)
            {
                max = i;
            }
        }

        return max;
    }

    public static int[] minMax(int[] arr)
    {
        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < arr.length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return new int[] {min, max};
    }
}