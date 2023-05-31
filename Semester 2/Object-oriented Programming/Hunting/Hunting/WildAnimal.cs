namespace Hunting;

public class WildAnimal
{
    protected double weight;
    protected bool sex; // true - male, false - female

    public bool isMale()
    {
        return sex;
    }

    public double getWeight()
    {
        return weight;
    }

    public WildAnimal(double weight, bool sex)
    {
        this.weight = weight;
        this.sex = sex;
    }

    public virtual bool IsElephant()
    {
        return false;
    }

    public virtual bool IsRhino()
    {
        return false;
    }

    public virtual bool IsLion()
    {
        return false;
    }
}

public class Elephant : WildAnimal
{
    public double rightTrunkLength { get; }
    public double leftTrunkLength { get; }

    public Elephant(double weight, double rightTrunkLength, double leftTrunkLength, bool sex) : base(weight, sex)
    {
        this.rightTrunkLength = rightTrunkLength;
        this.leftTrunkLength = leftTrunkLength;
    }

    public override bool IsElephant()
    {
        return true;
    }
}

public class Rhino : WildAnimal
{
    public double hornWeight { get; }

    public Rhino(double weight, double hornWeight, bool sex) : base(weight, sex)
    {
        this.hornWeight = hornWeight;
    }

    public override bool IsRhino()
    {
        return true;
    }
}

public class Lion : WildAnimal
{
    public Lion(double weight, bool sex) : base(weight, sex)
    {

    }

    public override bool IsLion()
    {
        return true;
    }
}