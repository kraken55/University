namespace FishingContest;

struct Catch
{
    public string time { get; }
    public string species { get; }
    public double weight { get; }
    public double length { get; }

    public Catch(string time, string species, double weight, double length)
    {
        this.time = time;
        this.species = species;
        this.weight = weight;
        this.length = length;
    }
}

class Fisherman
{
    public string name { get; }
    public List<Catch> catches { get; }

    public Fisherman(string name, List<Catch> catches)
    {
        this.name = name;
        this.catches = catches;
    }

    public int harcsak()
    {
        bool foundAppropriatePonty = false;
        int appropriateCatfishCount = 0;
        for (int i = 0; i < catches.Count; i++)
        {
            if (catches[i].species == "ponty" && catches[i].weight >= 1)
            {
                foundAppropriatePonty = true;
            }

            if (foundAppropriatePonty && catches[i].species == "harcsa" && catches[i].length >= 1)
            {
                appropriateCatfishCount++;
            }
        }

        return appropriateCatfishCount;
    }
}