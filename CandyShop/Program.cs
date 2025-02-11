using CandyShop.Views;
using CandyShop.Data;

namespace CandyShop
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            DatabaseHandler databaseHandler = new();
            databaseHandler.CreateDatabase();

            //if (!File.Exists(Configuration.DocPath))
            //    DataSeed.SeedData();

            ProductView.RunMainMenu();
        }
    }
}
