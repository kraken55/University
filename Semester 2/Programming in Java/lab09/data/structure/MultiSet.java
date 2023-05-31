package data.structure;

import java.util.HashMap;

public class MultiSet<E>
{
    private HashMap<E, Integer> elemToCount;

    public MultiSet(HashMap<E, Integer> starterValues)
    {
        elemToCount = starterValues;
    }

    public MultiSet(E[] starterValues)
    {
        elemToCount = new HashMap<>();

        for (E e : starterValues) 
        {
            this.add(e);
        }
    }

    public int size()
    {
        int size = 0;

        for (E e : elemToCount.keySet()) 
        {
            size += this.getCount(e);
        }

        return size;
    }

    public void add(E elem)
    {
        if (!elemToCount.containsKey(elem))
        {
            elemToCount.put(elem, 1);
        }
        else
        {
            elemToCount.put(elem, elemToCount.get(elem) + 1);
        }
    }

    public int getCount(E elem)
    {
        if (!elemToCount.containsKey(elem))
        {
            return 0;
        }

        return elemToCount.get(elem);
    }

    public MultiSet<E> intersect(MultiSet<E> that)
    {
        HashMap<E, Integer> intersect = new HashMap<>();

        for (E key : this.elemToCount.keySet())
        {
            if (that.getCount(key) != 0)
            {
                intersect.put(key, this.getCount(key) < that.getCount(key) ? this.getCount(key) : that.getCount(key));
            }
        }

        return new MultiSet<>(intersect);
    }

    public int countExcept(E key)
    {
        int count = 0;

        for (E e : elemToCount.keySet()) 
        {
            if (e != key)
            {
                count += this.getCount(e);
            }
        }

        return count;
    }
}