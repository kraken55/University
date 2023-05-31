package myarray.util;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import org.junit.jupiter.params.provider.ValueSource;

public class ArrayUtilTest 
{
    @Test
    public void maxLength0()
    {
        int[] arr = new int[0];

        assertEquals(0, ArrayUtil.max(arr));
        assertEquals(0, ArrayUtil.max2(arr));
        assertEquals(0, ArrayUtil.max3(arr));
        assertEquals(0, ArrayUtil.max4(arr));
    }

    @ParameterizedTest
    @ValueSource(ints = {0, 1, 10, 5, 6, 100, 40132, Integer.MAX_VALUE, Integer.MIN_VALUE})
    void maxLength1(int num)
    {
        assertEquals(num, ArrayUtil.max(new int[] {num}));
        assertEquals(num, ArrayUtil.max2(new int[] {num}));
        assertEquals(num, ArrayUtil.max3(new int[] {num}));
        assertEquals(num, ArrayUtil.max4(new int[] {num}));
    }

    @ParameterizedTest
    @CsvSource({"3,6", "10,8", "60, 90", "24, 3", "40,40"})
    void maxLength2(int num1, int num2)
    {
        int max = Math.max(num1, num2);
        assertEquals(max, ArrayUtil.max(new int[] {num1, num2}));
        assertEquals(max, ArrayUtil.max2(new int[] {num1, num2}));
        assertEquals(max, ArrayUtil.max3(new int[] {num1, num2}));
        assertEquals(max, ArrayUtil.max4(new int[] {num1, num2}));
    }

    @ParameterizedTest
    @ValueSource(ints = {2, 4, 3, 21, 5345, 27834, 3234})
    void minMax1(int num)
    {
        int[] check = new int[] {num, num};
        assertArrayEquals(check, ArrayUtil.minMax(new int[] {num}));
    }
}
