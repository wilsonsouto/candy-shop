internal class Program
{
    private static void Main(string[] args)
    {
        Program program = new Program();

        program.PrintHeader();

        while (true)
        {
            string usersChoice = Console.ReadLine().ToUpperInvariant();

            switch (usersChoice)
            {
                case "V":
                    program.ViewProducts();
                    break;
                case "A":
                    program.AddProduct();
                    break;
                case "D":
                    program.DeleteProduct();
                    break;
                case "U":
                    program.UpdateProduct();
                    break;
                case "Q":
                    Console.WriteLine("Exiting the program");
                    return;
                default:
                    Console.WriteLine(program.GetMenu("Invalid option. Please choose one of the above:"));
                    break;
            }

            Console.WriteLine("Press any key to go back on the menu");
            Console.Clear();
        }
    }

    void ViewProducts()
    {
        Console.WriteLine("User chose to view the products");
    }

    void AddProduct()
    {
        Console.WriteLine("User chose to add the product");
    }

    void DeleteProduct()
    {
        Console.WriteLine("User chose to delete the product");
    }

    void UpdateProduct()
    {
        Console.WriteLine("User chose to update the product");
    }

    void PrintHeader()
    {
        string shopName = "Mary's Candy Shop";
        string separator = "--------------------------------------------------";
        DateTime currentDate = DateTime.Now;
        decimal todaysProfit = 5.5m;
        bool targetAchieved = false;

        Console.WriteLine($"{shopName}\n" +
        $"{separator}\n" +
        $"Today's date: {currentDate:dd/MM/yyyy}\n" +
        $"Days since opening: {GetDaysSinceOpening()}\n" +
        $"Today's profit: $ {todaysProfit}\n" +
        $"Today's target achieved: {targetAchieved}\n" +
        $"{separator}\n" +
        $"{GetMenu("Choose one option:")}");
    }

    string GetMenu(string message)
    {
        return
        $"{message}\n" +
        "'V' to view products\n" +
        "'A' to add product\n" +
        "'D' to delete product\n" +
        "'U' to update product\n" +
        "'Q' to quit the program\n";
    }

    int GetDaysSinceOpening()
    {
        DateTime openingDate = new DateTime(1997, 1, 25);
        TimeSpan timeDifference = DateTime.Now - openingDate;

        return timeDifference.Days;
    }
}
