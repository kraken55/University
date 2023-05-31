package data.structure;

import org.junit.Assert;
import org.junit.Test;

public class MultiSetTest 
{
    @Test
    public void testMultiSetInteger()
    {
        MultiSet<Integer> msi = new MultiSet<>(new Integer[] {1, 2, 1, 2, 1, 3, 4});
        msi.add(4);
        msi.add(5);

        Assert.assertEquals(3, msi.getCount(1));
        Assert.assertEquals(2, msi.getCount(2));
        Assert.assertEquals(1, msi.getCount(3));
        Assert.assertEquals(2, msi.getCount(4));
        Assert.assertEquals(1, msi.getCount(5));
        Assert.assertEquals(0, msi.getCount(100));
    }
    
    @Test
    public void testMultiSetString()
    {
        MultiSet<String> mss = new MultiSet<>(new String[] {"a", "b", "abc", "cba", "cba"});
        mss.add("a");
        mss.add("b");

        Assert.assertEquals(2, mss.getCount("a"));
        Assert.assertEquals(2, mss.getCount("b"));
        Assert.assertEquals(1, mss.getCount("abc"));
        Assert.assertEquals(2, mss.getCount("cba"));
        Assert.assertEquals(0, mss.getCount("róka"));
    }

    @Test
    public void testCountExcept()
    {
        MultiSet<Integer> msi = new MultiSet<>(new Integer[] {1, 2, 1, 2, 1, 3, 4, 4, 4, 1, 2});
        Assert.assertEquals(7, msi.countExcept(1));
        Assert.assertEquals(8, msi.countExcept(2));
        Assert.assertEquals(8, msi.countExcept(4));
        Assert.assertEquals(msi.size(), msi.countExcept(100));
    }

    @Test
    public void testIntersect()
    {
        MultiSet<Integer> msi1 = new MultiSet<>(new Integer[] {1, 2, 1, 2, 1, 3, 4, 4, 4, 1, 2});
        MultiSet<Integer> msi2 = new MultiSet<>(new Integer[] {1, 2, 2, 3, 4, 4, 4, 4, 4, 5, 6, 7, 8, 9, 10});
        MultiSet<Integer> msIntersect = msi1.intersect(msi2);

        Assert.assertEquals(1, msIntersect.getCount(1));
        Assert.assertEquals(2, msIntersect.getCount(2));
        Assert.assertEquals(1, msIntersect.getCount(3));
        Assert.assertEquals(3, msIntersect.getCount(4));
        Assert.assertEquals(0, msIntersect.getCount(5));
        Assert.assertEquals(0, msIntersect.getCount(9));
    }
}
