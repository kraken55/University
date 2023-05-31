namespace StarWars;

public abstract class Spaceship
{
    protected string name;
    protected int shield;
    protected int armor;
    protected int nSoldiers;

    protected Planet? currentlyDefending;

    public int GetShield()
    {
        return shield;
    }

    public Spaceship(string name, int shield, int armor, int nSoldiers)
    {
        this.name = name;
        this.shield = shield;
        this.armor = armor;
        this.nSoldiers = nSoldiers;
    }

    public void DefendPlanet(Planet p)
    {
        currentlyDefending = p;
        p.AddDefender(this);
    }

    public void LeavePlanet()
    {
        if (currentlyDefending == null)
        {
            System.Console.WriteLine("Error");
            return;
        }

        currentlyDefending.RemoveDefender(this);
        currentlyDefending = null;
    }

    public abstract double getFirepower();
}

public class BatteringRam : Spaceship
{
    public BatteringRam(string name, int shield, int armor, int nSoldiers) : base(name, shield, armor, nSoldiers)
    {

    }

    public override double getFirepower()
    {
        return armor / 2;
    }
}