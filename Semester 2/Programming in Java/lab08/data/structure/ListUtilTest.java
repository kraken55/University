package data.structure;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class ListUtilTest 
{
    @Test
    public void testDivision()
    {
        assertEquals(new ArrayList<Integer>(), ListUtil.divisors(0));
        assertEquals(new ArrayList<Integer>(List.of(1)), ListUtil.divisors(1));
        assertEquals(new ArrayList<Integer>(List.of(1, 2, 4, 8, 16, 32, 64)), ListUtil.divisors(64));
    }

    @Test
    public void testStartsEndsWithSame()
    {
        ArrayList<String> testlist = new ArrayList<String>();
        ArrayList<String> output = new ArrayList<String>();
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add("");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add(null);
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add(" ");
        output.add(" ");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add("x");
        output.add("x");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add("");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add("different start and end?");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));

        testlist.add("ends and starts the same");
        output.add("ends and starts the same");
        assertEquals(output, ListUtil.withSameStartEnd(testlist));
    }

    @Test
    public void testMaxToFront()
    {
        ListUtil.maxToFront(null);
        ListUtil.maxToFront(new ArrayList<String>());

        assertEquals(new ArrayList<String>(List.of("abc")), new ArrayList<String>(List.of("abc")));
        assertEquals(new ArrayList<String>(List.of("you", "can", "succeed")), new ArrayList<String>(List.of("can", "you", "succeed")));
        assertEquals(new ArrayList<String>(List.of("2000", "-123", "100")), new ArrayList<String>(List.of("-123", "2000", "100")));
    }
}
