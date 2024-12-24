internal class Program
{
    private static void Main(string[] args)
    {
        string shopName = "Mary's Candy Shop";
        string separator = "--------------------------------------------------";
        DateTime currentDate = DateTime.Now;
        int daysSinceOpening = 1;
        decimal todaysProfit = 5.5m;
        bool targetAchieved = false;
        string menu =
        "Choose one option:\n" +
        "'V' to view products\n" +
        "'A' to add product\n" +
        "'D' to delete product\n" +
        "'U' to update product\n";

        Console.WriteLine(shopName);
        Console.WriteLine(separator);
        Console.WriteLine("Today's date: " + currentDate);
        Console.WriteLine("Days since opening: " + daysSinceOpening);
        Console.WriteLine("Today's profit: $ " + todaysProfit);
        Console.WriteLine("Today's target achieved: " + targetAchieved);
        Console.WriteLine(separator);
        Console.WriteLine(menu);
    }
}
