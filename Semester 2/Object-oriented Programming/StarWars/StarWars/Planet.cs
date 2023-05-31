namespace StarWars;

using System.Collections.Generic;

public class Planet
{
    private string name;

    private List<Spaceship> defenders;

    public Planet(string name)
    {
        this.name = name;
        defenders = new List<Spaceship>();
    }

    public int CountDefenders()
    {
        return defenders.Count;
    }

    public void AddDefender(Spaceship s)
    {
        defenders.Add(s);
    }

    public void RemoveDefender(Spaceship s)
    {
        defenders.Remove(s);
    }
}