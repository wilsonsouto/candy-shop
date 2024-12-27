using CandyShop.Models;

namespace CandyShop.Controllers
{
    internal class ProductController
    {
        private readonly List<Product> _productList = new();

        private Product? _userProduct;

        internal List<Product> GetProducts()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Configuration.DocPath, true))
                {
                    reader.ReadLine(); // discard first line
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        var id = int.Parse(parts[0].Trim());
                        var name = parts[1].Trim();
                        var price = decimal.Parse(parts[2].Trim());

                        _userProduct = new Product(id, name, price);

                        if (!_productList.Any(p => p.Id == _userProduct.Id))
                        {
                            _productList.Add(_userProduct);
                        }

                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading products: " + ex.Message);
            }

            return _productList;
        }

        internal void AddProduct()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the product name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("Enter the product price: ");
                    var price = Console.ReadLine();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(price))
                    {
                        _userProduct = new Product(_productList.Count + 1, name, decimal.Parse(price));
                        _productList.Add(_userProduct);

                        using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath, true))
                        {
                            if (outputFile.BaseStream.Length <= 3)
                            {
                                outputFile.WriteLine("Id, Name, Price");
                            }

                            outputFile.WriteLine(_userProduct.ToString());
                        }

                        Console.WriteLine("Product saved.");
                        return;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving products: " + ex.Message);
                }
            }
        }

        internal void DeleteProduct() { }

        internal void UpdateProduct() { }
    }
}
