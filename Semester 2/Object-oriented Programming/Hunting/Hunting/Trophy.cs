namespace Hunting;

public class Trophy
{
    private string location;
    private string date;
    public WildAnimal species { get; }


    public Trophy(string location, string date, WildAnimal species)
    {
        this.location = location;
        this.date = date;
        this.species = species;
    }
}