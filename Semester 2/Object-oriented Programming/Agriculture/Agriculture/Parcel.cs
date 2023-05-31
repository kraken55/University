namespace Agriculture;

class Parcel
{
    private int plantingMonth;
    private Plant? plant = null;

    public void Plant(Plant plant, int currMonth)
    {
        if (this.plant != null)
        {
            throw new ArgumentException();
        }

        this.plant = plant;
        plantingMonth = currMonth;
    }

    public bool isRipe(int month)
    {
        return (plant != null && plant.isVegetable() && month - plantingMonth == plant.getRipeningTime());
    }

    public void Reap()
    {
        if (plant != null && plant.isVegetable())
        {
            plant = null;
        }
    }
}