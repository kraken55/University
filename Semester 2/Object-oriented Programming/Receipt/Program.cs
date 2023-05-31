namespace Receipt;

class Program
{
    static void Main(string[] args)
    {
        Infile infile = new Infile("input.txt");
        int sum = 0;
        while (infile.Read(out Receipt? receipt))
        {
            if (receipt == null)
            {
                continue;
            }

            sum += receipt.Sum;
        }

        System.Console.WriteLine(sum);
    }
}