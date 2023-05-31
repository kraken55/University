namespace Agriculture;

class Program
{
    static void Main(string[] args)
    {
        Garden garden = new Garden(5);
        Gardener gardener = new Gardener(garden);

        gardener.Plant(1, Potato.getInstance(), 3);
        gardener.Plant(2, Peas.getInstance(), 3);
        gardener.Plant(4, Peas.getInstance(), 3);

        Console.WriteLine("A betakarithato parcellak azonositoi: ");
        foreach (int i in gardener.garden.canReap(6))
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
    }
}
