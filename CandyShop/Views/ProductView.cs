using CandyShop.Controllers;
using CandyShop.Models;
using Spectre.Console;

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
                var usersChoice = AnsiConsole.Prompt(
                      new SelectionPrompt<Enums.MainMenuOptions>()
                          .Title("What would you like to do?")
                          .AddChoices(
                            Enums.MainMenuOptions.ViewProducts,
                            Enums.MainMenuOptions.AddProduct,
                            Enums.MainMenuOptions.DeleteProduct,
                            Enums.MainMenuOptions.UpdateProduct,
                            Enums.MainMenuOptions.QuitProgram));


                switch (usersChoice)
                {
                    case Enums.MainMenuOptions.ViewProducts:
                        var result = productController.GetProducts();
                        ViewProducts(result);
                        break;
                    case Enums.MainMenuOptions.AddProduct:
                        productController.AddProduct();
                        break;
                    case Enums.MainMenuOptions.DeleteProduct:
                        productController.DeleteProduct();
                        break;
                    case Enums.MainMenuOptions.UpdateProduct:
                        productController.UpdateProduct();
                        break;
                    case Enums.MainMenuOptions.QuitProgram:
                        Console.WriteLine("Exiting the program.");
                        return;
                }

                Console.WriteLine("\nPress any key to go back on the menu:");
                Console.ReadLine();
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
            $"{Separator}\n");
        }
    }
}
