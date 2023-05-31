namespace Agriculture;

class Plant
{
    protected int ripeningTime;

    protected Plant(int ripeningTime)
    {
        this.ripeningTime = ripeningTime;
    }

    public virtual bool isVegetable()
    {
        return false;
    }

    public virtual bool isFlower()
    {
        return false;
    }

    public int getRipeningTime()
    {
        return ripeningTime;
    }
}