namespace Receipt;

using TextFile;

class Receipt
{
    public string Customer { get; private set; }
    public int Sum { get; private set; }

    public Receipt(string customer, int sum)
    {
        Customer = customer;
        Sum = sum;
    }
}

class Infile
{
    TextFileReader reader;

    public Infile(string filename)
    {
        reader = new TextFileReader(filename);
    }

    public bool Read(out Receipt? receipt)
    {
        receipt = null;

        bool wasSuccessful = reader.ReadLine(out string line);
        if (wasSuccessful)
        {
            string[] tokens = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            for (int i = 1; i < tokens.Length; i += 2)
            {
                sum += Convert.ToInt32(tokens[i + 1]);
            }

            receipt = new Receipt(tokens[0], sum);
        }

        return wasSuccessful;
    }
}