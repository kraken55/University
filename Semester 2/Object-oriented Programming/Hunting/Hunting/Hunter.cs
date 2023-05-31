namespace Hunting;

using System.Collections.Generic;

public class Hunter 
{
    private string name;
    private string dateOfBirth;
    private List<Trophy> trophies;

    public Hunter(string name, string dateOfBirth)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        trophies = new List<Trophy>();
    }

    public void Hunt(string location, string date, WildAnimal species)
    {
        trophies.Add(new Trophy(location, date, species));
    }
    
    public void Read(string filename)
    {
        
    }

    public int countMaleLions()
    {
        int count = 0;

        foreach (Trophy trophy in trophies)
        {
            if (trophy.species.IsLion() && trophy.species.isMale())
            {
                count++;
            }
        }

        return count;
    }

    public double maxHornWeightBodyWeightRatio()
    {
        double maxRatio = 0;

        foreach (Trophy trophy in trophies)
        {
            if (trophy.species.IsRhino())
            {
                double currRatio = ((Rhino) trophy.species).hornWeight / trophy.species.getWeight();
                if (currRatio > maxRatio)
                {
                    maxRatio = currRatio;
                }
            }
        }

        return maxRatio;
    }

    public bool searchEqualTrunkLengthElephant()
    {
        foreach (Trophy trophy in trophies)
        {
            if (trophy.species.IsElephant() && ((Elephant) trophy.species).leftTrunkLength == ((Elephant) trophy.species).rightTrunkLength)
            {
                return true;
            }
        }

        return false;
    }
}