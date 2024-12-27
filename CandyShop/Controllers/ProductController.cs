using CandyShop.Models;

namespace CandyShop.Controllers
{
    internal class ProductController
    {
        internal List<Product> GetProducts()
        {
            List<Product> products = new();

            try
            {
                using (StreamReader reader = new(Configuration.DocPath))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');
                        var product = new Product(int.Parse(parts[0]));
                        product.Name = parts[1];
                        product.Price = decimal.Parse(parts[2]);
                        products.Add(product);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading products: " + ex.Message);
            }

            return products;
        }

        internal void AddProduct()
        {
            var id = GetProducts().Count;

            Console.WriteLine("Enter the product name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the product price:");
            var price = decimal.Parse(Console.ReadLine());

            try
            {
                using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath, true))
                {
                    outputFile.WriteLine($"{id}, {name}, {price}");
                }

                Console.WriteLine("Product saved.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving products: " + ex.Message);
            }
        }

        internal void DeleteProduct() { }

        internal void UpdateProduct() { }
    }
}
