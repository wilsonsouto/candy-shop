using CandyShop.Views;

namespace CandyShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            databaseHandler.CreateDatabase();

            if (!File.Exists(Configuration.DocPath))
                DataSeed.SeedData();

            ProductView.RunMainMenu();
        }
    }
}
