namespace Restaurant;

using System.Collections.Generic;
using TextFile;

class Program
{
    struct Dish
    {
        public string name { get; }
        public int quantity { get; }
        public int price { get; }

        public Dish(string name, int quantity, int price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }

    struct Order
    {
        public string time { get; }
        public string id { get; }
        public List<Dish> dishes { get; }

        public Order(string time, string id, List<Dish> dishes)
        {
            this.time = time;
            this.id = id;
            this.dishes = dishes;
        }
    }


    public static void Main(String[] args)
    {
        int maxSum = 0;
        string maxId = "";
        bool l = false;

        TextFileReader reader = new TextFileReader("input.txt");
        while (reader.ReadLine(out string line))
        {
            String[] splitLine = line.Split(' ');

            List<Dish> dishes = new List<Dish>();
            for (int i = 2; i < splitLine.Length; i += 3)
            {
                dishes.Add(new Dish(splitLine[i], Convert.ToInt32(splitLine[i + 1]), Convert.ToInt32(splitLine[i + 2])));
            }

            Order currOrder = new Order(splitLine[0], splitLine[1], dishes);

            bool isPancake = sumWithCondition(currOrder, out int sum);

            if (isPancake && !l)
            {
                l = true;
                maxSum = sum;
                maxId = currOrder.id;
            }
            else if (isPancake && l && maxSum < sum)
            {
                maxSum = sum;
                maxId = currOrder.id;
            }
        }

        if (l)
        {
            System.Console.WriteLine(maxId);
        }
        else
        {
            System.Console.WriteLine("nem volt palacsinta rendelés");
        }
    }

    static bool sumWithCondition(Order order, out int sum)
    {
        sum = 0;

        bool isPancake = false;
        for (int i = 0; i < order.dishes.Count; i++)
        {
            if (order.dishes[i].name == "palacsinta")
            {
                isPancake = true;
            }
            sum += order.dishes[i].price * order.dishes[i].quantity;
        }

        return isPancake;
    }
}
