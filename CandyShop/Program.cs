using CandyShop.Views;
using CandyShop.Data;

namespace CandyShop;

internal static class Program
{
    internal static void Main(string[] args)
    {
        DatabaseHandler databaseHandler = new();
        databaseHandler.CreateDatabase();

        // if (!File.Exists(Configuration.DocPath))
        //     DataSeed.SeedData();

        ProductView.RunMainMenu();
    }
}
