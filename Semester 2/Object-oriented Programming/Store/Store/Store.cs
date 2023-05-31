namespace StoreNsp;

using TextFile;

public struct Product
{
    public string name { get; }
    public int price { get; }

    public Product(string name, int price)
    {
        this.name = name;
        this.price = price;
    }
}

class Department
{
    private List<Product> products;

    public Department(string infile)
    {
        products = new List<Product>();

        TextFileReader productsReader = new TextFileReader(infile);
        while (productsReader.ReadLine(out string line))
        {
            string[] splitLine = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            products.Add(new Product(splitLine[0], Convert.ToInt32(splitLine[1])));
        }
    }

    public List<Product> getProductList()
    {
        return products;
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }
}

public class Store
{
    private Department food;
    private Department tech;

    public Store(string foodinfile, string techinfile)
    {
        food = new Department(foodinfile);
        tech = new Department(techinfile);
    }

    public List<Product> getFoodList()
    {
        return food.getProductList();
    }

    public List<Product> getTechList()
    {
        return tech.getProductList();
    }

    public void RemoveItem(Product product)
    {
        food.RemoveProduct(product);
        tech.RemoveProduct(product);
    }
}