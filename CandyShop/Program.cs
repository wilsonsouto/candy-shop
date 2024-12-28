using CandyShop.Views;

namespace CandyShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!File.Exists(Configuration.DocPath))
                DataSeed.SeedData();

            ProductView.RunMainMenu();
        }
    }
}
