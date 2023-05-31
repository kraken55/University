package text.to.numbers;

import java.io.*;
import java.util.Scanner;

public class SingleLineFile 
{
    public SingleLineFile(){}

    public static int addNumbers(String filename) throws IOException
    {
        File input = new File(filename);

        Scanner scanline = new Scanner(input);
        Scanner sc = null;

        String line;
        int sum = 0;

        try
        {
            if (scanline.hasNextLine())
            {
                line = scanline.nextLine();
            }
            else
            {
                throw new IllegalArgumentException("Empty file exception");
            }

            sc = new Scanner(line);
            while (sc.hasNext())
            {
                if (sc.hasNextInt())
                {
                    sum += sc.nextInt();
                }
                else
                {
                    String message = "Not a number: " + sc.next();
                    System.err.println(message);
                }
            }
        }
        catch (IllegalArgumentException e)
        {
            System.err.println("Exception: " + e.toString());
        }
        finally
        {
            scanline.close();
            if (sc != null)
            {
                sc.close();
            }
        }

        return sum;
    }
}