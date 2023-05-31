namespace Fish;

using TextFile;

/*
struct Catch
{
    public string time { get; }
    public string species { get; }
    public double weight { get; }
    public double length { get; }

    public Catch(string time, )
}
*/

class Fisherman
{
    public string Name { get; private set; }
    // public Catch[] catches { get; private set; }
    public double WeightOfTargetFish { get; private set; }

    public Fisherman(string name, double weight)
    {
        Name = name;
        WeightOfTargetFish = weight;
    }
}

class Infile
{
    private TextFileReader reader;

    public Infile(string filename)
    {
        reader = new TextFileReader(filename);
    }

    public bool Read(out Fisherman? fisherman)
    {
        fisherman = null;

        bool wasSuccessful = reader.ReadLine(out string line);

        if (wasSuccessful)
        {
            string[] tokens = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            double weightOfTargetFish = 0;
            for (int i = 1; i < tokens.Length; i += 4)
            {
                if (tokens[i + 1] == "ponty" && Convert.ToDouble(tokens[i + 3]) > 0.5)
                {
                    weightOfTargetFish += Convert.ToDouble(tokens[i + 2]);
                }
            }

            fisherman = new Fisherman(tokens[0], weightOfTargetFish);
        }

        return wasSuccessful;
    }
}