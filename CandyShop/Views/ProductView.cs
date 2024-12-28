using CandyShop.Controllers;
using CandyShop.Enums;
using CandyShop.Models;
using Spectre.Console;

namespace CandyShop.Views
{
    internal class ProductView
    {
        internal static void RunMainMenu()
        {
            ProductController productController = new();

            PrintHeader();

            while (true)
            {
                var usersChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                        .Title("What would you like to do?")
                        .AddChoices(
                            MainMenuOptions.ViewProductsList,
                            MainMenuOptions.ViewSingleProduct,
                            MainMenuOptions.AddProduct,
                            MainMenuOptions.DeleteProduct,
                            MainMenuOptions.UpdateProduct,
                            MainMenuOptions.QuitProgram
                        )
                );

                Console.Clear();

                switch (usersChoice)
                {
                    case MainMenuOptions.ViewProductsList:
                        var result = productController.GetProducts();
                        ViewProducts(result);
                        break;
                    case MainMenuOptions.ViewSingleProduct:
                        var productChoice = GetProductChoice();
                        ViewProduct(productChoice);
                        break;
                    case MainMenuOptions.AddProduct:
                        var product = GetProductInput();
                        productController.AddProduct(product);
                        break;
                    case MainMenuOptions.DeleteProduct:
                        var productToDelete = GetProductChoice();
                        productController.DeleteProduct(productToDelete);
                        break;
                    case MainMenuOptions.UpdateProduct:
                        var productToUpdate = GetProductChoice();
                        var updatedProduct = GetProductUpdateInput(productToUpdate);
                        productController.UpdateProduct(updatedProduct);
                        break;
                    case MainMenuOptions.QuitProgram:
                        Console.WriteLine("Exiting the program.");
                        return;
                }

                Console.WriteLine("\nPress any key to go back on the menu:");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PrintHeader()
        {
            string shopName = "Mary's Candy Shop";
            DateTime currentDate = DateTime.Now;
            decimal todaysProfit = 5.5m;
            bool targetAchieved = false;

            AnsiConsole.Write(
                new Panel(
                    new Markup(
                        $"Today's date: [bold]{currentDate:dd/MM/yyyy}[/]\n"
                            + $"Days since opening: [bold]{Helpers.ProductHelpers.GetDaysSinceOpening()}[/]\n"
                            + $"Today's profit: [bold]$ {todaysProfit}[/]\n"
                            + $"Today's target achieved: [bold]{targetAchieved}[/]\n"
                    )
                )
                    .Header($"[bold blue]{shopName}[/]")
                    .Padding(2, 1, 2, 0)
                    .Border(BoxBorder.Rounded)
            );
        }

        private static Product GetProductUpdateInput(Product product)
        {
            Console.WriteLine(
                "You'll be prompted with the choice to update each property. Press enter for Yes and N for No"
            );

            product.Name = AnsiConsole.Confirm("Update name?")
                ? Helpers.ProductHelpers.GetValidatedInput(
                    "Enter new product name: ",
                    "The product name must be at least 3 characters long and cannot be empty."
                )
                : product.Name;

            product.Price = AnsiConsole.Confirm("Update price?")
                ? Helpers.ProductHelpers.GetValidatedNumber(
                    "Enter the new product price: ",
                    "The product price must be a positive number greater than zero."
                )
                : product.Price;

            var updateType = AnsiConsole.Confirm("Update category?");

            if (updateType)
            {
                var type = AnsiConsole.Prompt(
                    new SelectionPrompt<ProductType>()
                        .Title("Product type: ")
                        .AddChoices(ProductType.ChocolateBar, ProductType.Lollipop)
                );

                if (type == ProductType.ChocolateBar)
                {
                    var cocoa = Helpers.ProductHelpers.GetValidatedNumber(
                        "Enter the new cocoa percentage: ",
                        "The cocoa percentage must be a positive number greater than zero."
                    );

                    return new ChocolateBar()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        CocoaPercentage = (int)cocoa,
                    };
                }

                var shape = Helpers.ProductHelpers.GetValidatedInput(
                    "Enter the new shape of the lollipop: ",
                    "The shape must be at least 3 characters long and cannot be empty."
                );

                return new Lollipop()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Shape = shape,
                };
            }

            return product;
        }

        private static void ViewProducts(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Type");
            table.AddColumn("Name");
            table.AddColumn("Price");
            table.AddColumn("Cocoa Percentage");
            table.AddColumn("Shape");

            foreach (Product product in products)
            {
                var productType = product is ChocolateBar ? "Chocolate Bar" : "Lollipop";
                var cocoaPercentage = product is ChocolateBar chocolateBar
                    ? chocolateBar.CocoaPercentage.ToString()
                    : "N/A";
                var shape = product is Lollipop lollipop ? lollipop.Shape : "N/A";

                table.AddRow(
                    product.Id.ToString(),
                    productType,
                    product.Name,
                    product.Price.ToString("C"),
                    cocoaPercentage,
                    shape
                );
            }

            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);
        }

        private static void ViewProduct(Product productChoice)
        {
            var panel = new Panel(productChoice.GetProductForPanel());
            panel.Header = new PanelHeader($"[bold blue]Product Info[/]");
            panel.Padding = new Padding(2, 0, 2, 1);
            panel.Border(BoxBorder.Rounded);

            AnsiConsole.Write(panel);
        }

        private static Product GetProductChoice()
        {
            var productController = new ProductController();
            var products = productController.GetProducts();
            var productsArray = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("Select the product:").AddChoices(productsArray)
            );

            var product = products.Single(x => x.Name == option);

            return product;
        }

        private static Product GetProductInput()
        {
            var name = Helpers.ProductHelpers.GetValidatedInput(
                "Enter the product name: ",
                "The product name must be at least 3 characters long and cannot be empty."
            );

            var price = Helpers.ProductHelpers.GetValidatedNumber(
                "Enter the product price: ",
                "The product price must be a positive number greater than zero."
            );

            var type = AnsiConsole.Prompt(
                new SelectionPrompt<ProductType>()
                    .Title("Select the product type: ")
                    .AddChoices(ProductType.ChocolateBar, ProductType.Lollipop)
            );

            if (type == ProductType.ChocolateBar)
            {
                var cocoa = Helpers.ProductHelpers.GetValidatedNumber(
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

            var shape = Helpers.ProductHelpers.GetValidatedInput(
                "Enter the shape of the lollipop: ",
                "The shape must be at least 3 characters long and cannot be empty."
            );

            return new Lollipop()
            {
                Name = name,
                Price = price,
                Shape = shape,
            };
        }
    }
}
