using CandyShop.Controllers;
using CandyShop.Enums;
using CandyShop.Helpers;
using CandyShop.Models;
using Spectre.Console;

namespace CandyShop.Views;

internal static class ProductView
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
                        + $"Days since opening: [bold]{ProductHelper.GetDaysSinceOpening()}[/]\n"
                        + $"Today's profit: [bold]$ {todaysProfit}[/]\n"
                        + $"Today's target achieved: [bold]{targetAchieved}[/]\n"
                )
            )
                .Header($"[bold blue]{shopName}[/]")
                .Padding(2, 1, 2, 0)
                .Border(BoxBorder.Rounded)
        );
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
            new SelectionPrompt<string>().Title("Select the product: ").AddChoices(productsArray)
        );

        var product = products.Single(x => x.Name == option);

        return product;
    }

    private static Product GetProductInput()
    {
        Console.Write(MessageHelper.Name);
        var nameInput = Console.ReadLine();

        while (!ValidationHelper.IsStringValid(nameInput))
        {
            Console.Write(MessageHelper.InvalidName);
            nameInput = Console.ReadLine();
        }

        Console.Write(MessageHelper.Price);
        var priceInput = Console.ReadLine();
        var priceValidation = ValidationHelper.IsPriceValid(priceInput);

        while (!priceValidation.IsValid)
        {
            Console.Write(priceValidation.ErrorMessage);
            priceInput = Console.ReadLine();
            priceValidation = ValidationHelper.IsPriceValid(priceInput);
        }

        var type = AnsiConsole.Prompt(
            new SelectionPrompt<ProductType>()
                .Title("Select the product type: ")
                .AddChoices(ProductType.ChocolateBar, ProductType.Lollipop)
        );

        if (type == ProductType.ChocolateBar)
        {
            Console.Write(MessageHelper.Cocoa);
            var cocoaInput = Console.ReadLine();
            var cocoaValidation = ValidationHelper.IsCocoaValid(cocoaInput);

            while (!cocoaValidation.IsValid)
            {
                Console.WriteLine(cocoaValidation.ErrorMessage);
                cocoaInput = Console.ReadLine();
                cocoaValidation = ValidationHelper.IsCocoaValid(cocoaInput);
            }

            return new ChocolateBar()
            {
                Name = nameInput!,
                Price = priceValidation.Price,
                CocoaPercentage = cocoaValidation.CocoaPercentage,
            };
        }

        Console.Write(MessageHelper.Shape);
        var shape = Console.ReadLine();

        while (!ValidationHelper.IsStringValid(shape))
        {
            Console.Write(MessageHelper.InvalidShape);
            shape = Console.ReadLine();
        }

        return new Lollipop()
        {
            Name = nameInput!,
            Price = priceValidation.Price,
            Shape = shape!,
        };
    }

    private static Product GetProductUpdateInput(Product product)
    {
        Console.WriteLine(
            "You'll be prompted with the choice to update each property. Press enter for Yes and N for No"
        );

        product.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>(MessageHelper.Name)
            : product.Name;


        product.Price = AnsiConsole.Confirm("Update price?")
            ? AnsiConsole.Ask<decimal>(MessageHelper.Price)
            : product.Price;


        var updateType = AnsiConsole.Confirm("Update category?");

        if (updateType)
        {
            var type = AnsiConsole.Prompt(
                new SelectionPrompt<ProductType>()
                    .Title("Product type: ")
                    .AddChoices(
                        ProductType.ChocolateBar,
                        ProductType.Lollipop)
            );

            if (type == ProductType.ChocolateBar)
            {
                Console.Write(MessageHelper.Cocoa);
                var cocoa = int.Parse(Console.ReadLine()!);

                return new ChocolateBar(product.Id)
                {
                    Name = product.Name,
                    Price = product.Price,
                    CocoaPercentage = cocoa,
                };
            }

            Console.Write(MessageHelper.Shape);
            var shape = Console.ReadLine();

            return new Lollipop(product.Id)
            {
                Name = product.Name,
                Price = product.Price,
                Shape = shape!,
            };
        }

        return product;
    }
}
