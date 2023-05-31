namespace Agriculture;

class Gardener
{
    public Garden garden { get; }

    public Gardener(Garden garden)
    {
        this.garden = garden;
    }

    public void Plant(int parcelId, Plant plant, int currMonth)
    {
        garden.Plant(parcelId, plant, currMonth);
    }
}