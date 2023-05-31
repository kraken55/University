namespace Agriculture;

class Garden
{
    private Parcel[] parcels;

    public Garden(int nParcels)
    {
        parcels = new Parcel[nParcels];
        for (int i = 0; i < nParcels; i++)
        {
            parcels[i] = new Parcel();
        }
    }

    public void Plant(int parcelId, Plant plant, int currMonth)
    {
        parcels[parcelId].Plant(plant, currMonth);
    }

    public void Reap(int parcelId)
    {
        parcels[parcelId].Reap();
    }

    public List<int> canReap(int month)
    {
        List<int> ret = new List<int>();

        for (int i = 0; i < parcels.Length; i++)
        {
            if (parcels[i].isRipe(month))
            {
                ret.Add(i);
            }
        }

        return ret;
    }
}