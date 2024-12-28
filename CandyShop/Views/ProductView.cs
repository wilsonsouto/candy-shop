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
                            Enums.MainMenuOptions.QuitProgram
                        )
                );

                switch (usersChoice)
                {
                    case Enums.MainMenuOptions.ViewProducts:
                        var result = productController.GetProducts();
                        ViewProducts(result);
                        break;
                    case Enums.MainMenuOptions.AddProduct:
                        var product = GetProductInput();
                        productController.AddProduct(product);
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
                Console.WriteLine(product.GetProductsForCsv(product.Id));
            }
            Console.WriteLine(Separator);
        }

        private static void PrintHeader()
        {
            string shopName = "Mary's Candy Shop";
            DateTime currentDate = DateTime.Now;
            decimal todaysProfit = 5.5m;
            bool targetAchieved = false;

            Console.WriteLine(
                $"{shopName}\n"
                    + $"{Separator}\n"
                    + $"Today's date: {currentDate:dd/MM/yyyy}\n"
                    + $"Days since opening: {Helpers.GetDaysSinceOpening()}\n"
                    + $"Today's profit: $ {todaysProfit}\n"
                    + $"Today's target achieved: {targetAchieved}\n"
                    + $"{Separator}\n"
            );
        }

        public static Product GetProductInput()
        {
            var name = GetValidInput(
                "Enter the product name: ",
                input => !string.IsNullOrEmpty(input) && input.Length >= 3,
                "The product name must be at least 3 characters long and cannot be empty."
            );

            var price = GetValidNumber(
                "Enter the product price: ",
                "The product price must be a positive number greater than zero."
            );

            var type = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ProductType>()
                    .Title("Select the product type: ")
                    .AddChoices(Enums.ProductType.ChocolateBar, Enums.ProductType.Lollipop)
            );

            if (type == Enums.ProductType.ChocolateBar)
            {
                var cocoa = GetValidNumber(
                    "Enter the cocoa percentage: ",
                    "The cocoa percentage must be a positive number greater than zero."
                );

                return new ChocolateBar()
                {
                    Name = name,
                    Price = price,
                    CocoaPercentage = (int)cocoa,
                };
            }

            var shape = GetValidInput(
                "Enter the shape of the lollipop:",
                input => !string.IsNullOrEmpty(input) && input.Length >= 3,
                "The shape must be at least 3 characters long and cannot be empty."
            );

            return new Lollipop()
            {
                Name = name,
                Price = price,
                Shape = shape,
            };
        }

        private static string GetValidInput(
            string prompt,
            Func<string, bool> validator,
            string errorMessage
        )
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    try
                    {
                        if (!validator(input))
                            throw new ArgumentException(errorMessage);

                        return input;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static decimal GetValidNumber(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();

                try
                {
                    if (
                        string.IsNullOrEmpty(input)
                        || !decimal.TryParse(input, out var result)
                        || result <= 0
                    )
                    {
                        throw new ArgumentException(errorMessage);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
