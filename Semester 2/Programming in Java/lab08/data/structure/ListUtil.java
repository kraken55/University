package data.structure;

import java.util.ArrayList;
import java.util.Collections;

public class ListUtil 
{
    public static ArrayList<Integer> divisors(int num)
    {
        ArrayList<Integer> divisors = new ArrayList<Integer>();

        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                divisors.add(i);
            }
        }

        return divisors;
    }

    public static ArrayList<String> withSameStartEnd(ArrayList<String> list)
    {
        ArrayList<String> ret = new ArrayList<String>();

        for (String elem : list)
        {
            if (elem != null && elem != "" && elem.charAt(0) == elem.charAt(elem.length() - 1))
            {
                ret.add(elem);
            }
        }

        return ret;
    }

    public static void maxToFront(ArrayList<String> list)
    {
        if (list == null || list.size() == 0)
        {
            return;
        }

        String maxElem = Collections.max(list);
        list.remove(maxElem);
        list.add(0, maxElem);
    }
}
