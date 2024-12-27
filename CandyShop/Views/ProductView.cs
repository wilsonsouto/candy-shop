using CandyShop.Controllers;
using CandyShop.Models;

namespace CandyShop.Views
{
    internal class ProductView
    {
        private const string Separator = "--------------------------------------------------";

        internal static void RunMainMenu()
        {
            ProductController productController = new();

            PrintHeader();

            while (true)
            {
                string? usersChoice = Console.ReadLine().ToUpperInvariant();

                switch (usersChoice)
                {
                    case "V":
                        var result = productController.GetProducts();
                        ViewProducts(result);
                        break;
                    case "A":
                        productController.AddProduct();
                        break;
                    case "D":
                        productController.DeleteProduct();
                        break;
                    case "U":
                        productController.UpdateProduct();
                        break;
                    case "Q":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nPress any key to go back on the menu:");
                Console.ReadLine();
                Console.WriteLine(GetMenu());
            }
        }

        internal static void ViewProducts(List<Product> products)
        {
            Console.WriteLine($"The product list contains {products.Count} product(s).");

            Console.WriteLine(Separator);
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine(Separator);
        }

        private static void PrintHeader()
        {
            string shopName = "Mary's Candy Shop";
            DateTime currentDate = DateTime.Now;
            decimal todaysProfit = 5.5m;
            bool targetAchieved = false;

            Console.WriteLine($"{shopName}\n" +
            $"{Separator}\n" +
            $"Today's date: {currentDate:dd/MM/yyyy}\n" +
            $"Days since opening: {Helpers.GetDaysSinceOpening()}\n" +
            $"Today's profit: $ {todaysProfit}\n" +
            $"Today's target achieved: {targetAchieved}\n" +
            $"{Separator}\n" +
            $"{GetMenu()}");
        }

        private static string GetMenu()
        {
            return
            "Choose one option:\n" +
            "'V' to view products\n" +
            "'A' to add product\n" +
            "'D' to delete product\n" +
            "'U' to update product\n" +
            "'Q' to quit the program\n";
        }
    }
}
