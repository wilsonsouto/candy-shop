internal class Program
{
    public Dictionary<int, string> products = new();

    public string DocPath = "/home/wilson/Repositories/candy-shop/CandyShop/products.txt";

    public const string EmptyProductList = "The product list is empty.";

    private static void Main(string[] args)
    {
        Program program = new Program();

        if (File.Exists(program.DocPath))
            program.LoadData();

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

            Console.WriteLine("\nPress any key to go back on the menu:");
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

            foreach (KeyValuePair<int, string> product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            return;
        }

        Console.WriteLine(EmptyProductList);
    }

    void AddProduct()
    {
        Console.WriteLine("Enter a product name:");

        while (true)
        {
            var product = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(product) && product.Length > 2)
            {
                var result = CapitalizeFirstLetter(product);

                if (!products.ContainsValue(result))
                {
                    int newKey = products.Count > 0 ? products.Keys.Max() + 1 : 1;
                    products.TryAdd(newKey, result);
                    Console.WriteLine("Product added successfully.");
                    return;
                }

                Console.WriteLine("Product already exists. please insert a different product:");
            }
            else
            {
                Console.WriteLine("Product cannot be empty, please insert a valid product:");
            }
        }
    }

    void DeleteProduct()
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Enter a product id:");

            while (true)

            {
                foreach (KeyValuePair<int, string> product in products)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }

                var indexProduct = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(indexProduct))
                {
                    if (products.ContainsKey(int.Parse(indexProduct)))
                    {
                        products.Remove(int.Parse(indexProduct));
                        Console.WriteLine("Product removed successfully.");
                        return;
                    }

                    Console.WriteLine("Product id not found, please insert a valid id:");
                }
            }
        }

        Console.WriteLine(EmptyProductList);
    }

    void UpdateProduct()
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Enter a product id:");

            while (true)
            {
                foreach (KeyValuePair<int, string> product in products)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }

                var productIndex = Console.ReadLine();

                if (products.ContainsKey(int.Parse(productIndex)))
                {
                    Console.WriteLine("Enter the new product name:");
                    var newProductName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(newProductName) && newProductName.Length > 2)
                    {
                        var result = CapitalizeFirstLetter(newProductName);

                        if (!products.ContainsValue(result))
                        {
                            products[int.Parse(productIndex)] = result;
                            Console.WriteLine("Product added successfully.");
                            return;
                        }

                        Console.WriteLine("Product already exists. please insert a different product:");
                    }
                    else
                    {
                        Console.WriteLine("Product cannot be empty, please insert a valid product:");
                    }

                }
                else
                {
                    Console.WriteLine("Product id not found, please insert a valid id:");
                }
            }
        }

        Console.WriteLine(EmptyProductList);
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
                    outputFile.WriteLine($"{product.Key},{product.Value}");
                }

                Console.WriteLine("Products saved.");
            }
        }
    }

    void LoadData()
    {
        using (StreamReader reader = new(DocPath))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                string[] parts = line.Split(',');
                products.Add(int.Parse(parts[0]), parts[1]);
                line = reader.ReadLine();
            }
        }
    }

    string CapitalizeFirstLetter(string product)
    {
        return char.ToUpper(product[0]) + product.Substring(1).ToLower();
    }
}
