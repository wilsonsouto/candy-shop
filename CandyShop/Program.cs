internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Mary's Candy Shop");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Today's date: " + DateTime.Now);
        Console.WriteLine("Days since opening: " + 1);
        Console.WriteLine("Today's profit: $ " + 5.5m);
        Console.WriteLine("Today's target achieved: " + false);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Choose one option: ");
        Console.WriteLine("'V' to view product");
        Console.WriteLine("'A' to add product");
        Console.WriteLine("'D' to delete product");
        Console.WriteLine("'U' to update product");
    }
}
