namespace Fish;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-Us");

        Infile infile = new Infile("fishinginput.txt");
        while (infile.Read(out Fisherman? fisherman))
        {
            if (fisherman == null)
            {
                continue;
            }
            System.Console.WriteLine(fisherman.WeightOfTargetFish);
            if (fisherman.WeightOfTargetFish >= 1)
            {
                System.Console.WriteLine(fisherman.Name);
                return;
            }
        }
    }
}
