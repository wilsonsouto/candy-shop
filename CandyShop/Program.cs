using CandyShop.Controllers;
using CandyShop.Views;

namespace CandyShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProductsController productsController = new();

            if (File.Exists(Configuration.DocPath))
                productsController.LoadData();

            ProductView.RunMainMenu();
        }
    }

}
