namespace FishingContest;

using TextFile;

class Infile
{
    private TextFileReader reader;

    public Infile(string filename)
    {
        reader = new TextFileReader(filename);
    }

    public bool ReadFisherman(out Fisherman? fisherman)
    {
        bool wasSuccessful = reader.ReadLine(out string line);

        if (wasSuccessful)
        {
            string[] tokens = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            List<Catch> currCatches = new List<Catch>();
            for (int i = 1; i <= tokens.Length - 1; i += 4)
            {
                Catch curr = new Catch(tokens[i], tokens[i + 1], double.Parse(tokens[i + 3]), double.Parse(tokens[i + 2]));
                currCatches.Add(curr);
            }

            fisherman = new Fisherman(tokens[0], currCatches);
        }
        else
        {
            fisherman = null;
        }

        return wasSuccessful;
    }
}