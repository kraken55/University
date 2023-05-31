namespace Agriculture;

class Vegetable : Plant
{
    public override bool isVegetable()
    {
        return true;
    }

    protected Vegetable(int ripeningTime) : base(ripeningTime) { }
}

class Potato : Vegetable
{
    private static Potato? instance = null;
    private Potato() : base(5) { }
    
    public static Potato getInstance()
    {
        if (instance == null)
        {
            instance = new Potato();
        }

        return instance;
    }
}

class Peas : Vegetable
{
    private static Peas? instance = null;
    private Peas() : base(3) { }
    
    public static Peas getInstance()
    {
        if (instance == null)
        {
            instance = new Peas();
        }

        return instance;
    }
}

class Onion : Vegetable
{
    private static Onion? instance = null;
    private Onion() : base(4) { }
    
    public static Onion getInstance()
    {
        if (instance == null)
        {
            instance = new Onion();
        }

        return instance;
    }
}