namespace StoreNsp;

using TextFile;

public class Customer
{
    public string name { get; }
    private List<string> shoppingList;
    private List<Product> shoppingCart = new List<Product>();

    public Customer(string shoppingListInfile)
    {
        TextFileReader shoppingListReader = new TextFileReader(shoppingListInfile);
        shoppingListReader.ReadString(out string name);
        this.name = name;

        shoppingList = new List<string>();
        while (shoppingListReader.ReadLine(out string product))
        {
            shoppingList.Add(product);
        }
    }

    public void printShoppingCart()
    {
        foreach (Product pr in shoppingCart)
        {
            System.Console.WriteLine($"{pr.name} {pr.price}");
        }
    }

    public void GoShopping(Store store)
    {
        foreach (string product in shoppingList)
        {
            bool l = Search(product, store, out Product foundProduct);
            if (l)
            {
                Purchase(foundProduct, store);
            }
        }
    }

    private bool Search(string name, Store store, out Product product)
    {
        bool success = false;
        product = new Product("", 0);

        foreach (Product pr in store.getFoodList())
        {
            if (pr.name == name && !success)
            {
                success = true;
                product = pr;
            }
        }

        if (!success)
        {
            foreach (Product pr in store.getTechList())
            {
                if (pr.name == name && !success)
                {
                    success = true;
                    product = findCheapest(store, product);
                }
            }
        }

        return success;
    }

    private Product findCheapest(Store store, Product product)
    {
        int minPrice = product.price;
        Product minProduct = product;

        foreach (Product pr in store.getTechList())
        {
            if (pr.name == product.name && pr.price < minPrice)
            {
                minPrice = pr.price;
                minProduct = pr;
            }
        }
        
        return minProduct;
    }

    private void Purchase(Product product, Store store)
    {
        shoppingCart.Add(product);
        store.RemoveItem(product);
    }
}