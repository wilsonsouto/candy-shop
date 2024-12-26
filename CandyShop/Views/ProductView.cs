using CandyShop.Controllers;

namespace CandyShop.Views
{
    internal class ProductView
    {
        internal static void RunMainMenu()
        {
            ProductsController productsController = new();
            
            PrintHeader();

            while (true)
            {
                string usersChoice = Console.ReadLine().ToUpperInvariant();

                switch (usersChoice)
                {
                    case "V":
                        productsController.ViewProducts();
                        break;
                    case "A":
                        productsController.AddProduct();
                        break;
                    case "D":
                        productsController.DeleteProduct();
                        break;
                    case "U":
                        productsController.UpdateProduct();
                        break;
                    case "Q":
                        productsController.SaveProducts();
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

        private static void PrintHeader()
        {
            string shopName = "Mary's Candy Shop";
            string separator = "--------------------------------------------------";
            DateTime currentDate = DateTime.Now;
            decimal todaysProfit = 5.5m;
            bool targetAchieved = false;

            Console.WriteLine($"{shopName}\n" +
            $"{separator}\n" +
            $"Today's date: {currentDate:dd/MM/yyyy}\n" +
            $"Days since opening: {Helpers.GetDaysSinceOpening()}\n" +
            $"Today's profit: $ {todaysProfit}\n" +
            $"Today's target achieved: {targetAchieved}\n" +
            $"{separator}\n" +
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


