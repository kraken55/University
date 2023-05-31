package cafe;

import org.junit.Assert;
import org.junit.Test;

public class CafeTest 
{
    @Test
    public void testMinor()
    {
        Minor minorFalse = new Minor("Jake", 12);
        Minor minorTrue = new Minor("WOEOWE", 17);
        Bartender bartender = new Bartender(16);
        Assert.assertEquals(false, bartender.order(minorFalse));
        Assert.assertEquals(true, bartender.order(minorTrue));
    }

    @Test
    public void testAdult()
    {
        Adult adult1 = new Adult("HOHOHO", 70);
        Adult adult2 = new Adult("HOHOHO", 21);
        Bartender bartender = new Bartender(18);
        Assert.assertEquals(true, bartender.order(adult1));
        Assert.assertEquals(true, bartender.order(adult2));
    }
}
