using CandyShop.Controllers;
using CandyShop.Views;

namespace CandyShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProductController productController = new ProductController();
            productController.CreateDatabase();
            
            if (!File.Exists(Configuration.DocPath))
                DataSeed.SeedData();

            ProductView.RunMainMenu();
        }
    }
}
