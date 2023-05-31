namespace FishingContest;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        List<string> names = new List<string>();
        Infile input = new Infile("input.txt");
        while (input.ReadFisherman(out Fisherman? curr))
        {
            if (curr == null)
            {
                continue;
            }

            if (curr.harcsak() >= 4)
            {
                names.Add(curr.name);
            }
        }

        foreach(string elem in names)
        {
            System.Console.WriteLine(elem);
        }
    }
}
