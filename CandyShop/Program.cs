using CandyShop.Views;

namespace CandyShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataSeed.SeedData();

            ProductView.RunMainMenu();
        }
    }
}
