namespace velocity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double s, t;
            double v;
            Console.Write("Megtett út: ");
            if ( (double.TryParse(Console.ReadLine(), out s)) && (s >= 0) )
            {
                Console.Write("Eltelt idő: ");
                if ( (double.TryParse(Console.ReadLine(), out t)) && (t > 0) )
                {
                    v = s / t;

                    Console.WriteLine($"A sebesség {v}");
                }
                else
                {
                    Console.WriteLine("HIBA (idő)");
                }
            }
            else
            {
                Console.WriteLine("HIBA (út)");
            }
        }
    }
}
