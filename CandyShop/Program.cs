internal class Program
{
    public Dictionary<int, string> products = new();

    public string DocPath = "/home/wilson/Repositories/candy-shop/CandyShop/products.txt";

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
                    program.SaveProducts();
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress any key to go back on the menu: ");
            Console.ReadLine();
            Console.WriteLine(program.GetMenu());
        }
    }

    void ViewProducts()
    {
        if (products.Count > 0)
        {
            var productsCount = products.Count == 1 ? $"The product list contains {products.Count} product." : $"The product list contains {products.Count} products.";
            Console.WriteLine(productsCount);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            return;
        }

        Console.WriteLine("The product list is empty.");
    }

    void AddProduct()
    {
        Console.WriteLine("Enter a product name: ");

        while (true)
        {
            var product = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(product))
            {
                var result = CapitalizeFirstLetter(product);

                if (!products.ContainsValue(result))
                {
                    int newKey = products.Count > 0 ? products.Keys.Max() + 1 : 1;
                    products.TryAdd(newKey, result);
                    Console.WriteLine("Product added successfully.");
                    return;
                }

                Console.WriteLine("The product already exists. Please insert a different product: ");
            }
            else
            {
                Console.WriteLine("Product cannot be empty. Please insert a valid product:");
            }
        }

        string CapitalizeFirstLetter(string product)
        {
            return char.ToUpper(product[0]) + product.Substring(1).ToLower();
        }
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
        $"{GetMenu()}");
    }

    string GetMenu()
    {
        return
        "Choose one option:\n" +
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
    void SaveProducts()
    {
        if (products.Count > 0)
        {
            using (StreamWriter outputFile = new StreamWriter(DocPath))
            {
                foreach (KeyValuePair<int, string> product in products)
                {
                    outputFile.WriteLine(product);
                }

                Console.WriteLine("Products saved.");
            }
        }
    }
}
