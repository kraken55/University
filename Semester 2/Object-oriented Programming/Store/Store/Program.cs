namespace StoreNsp;

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store("food.txt", "tech.txt");
        Customer customer = new Customer("customer.txt");
        customer.GoShopping(store);
        Console.WriteLine(customer.name + " nevű vásárló az alábbi termékeket vásárolta:");
        customer.printShoppingCart();
    }
}
