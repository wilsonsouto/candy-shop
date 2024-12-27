using CandyShop.Models;

namespace CandyShop.Controllers
{
    internal class ProductsController
    {
        private readonly Products _products = new Products();

        private const string EmptyProductList = "The product list is empty.";

        internal List<string> GetData()
        {
            List<string> products = new();

            try
            {
                using (StreamReader reader = new(Configuration.DocPath))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');
                        products.Add(line);
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
            Console.WriteLine("Enter the product name:");

            var product = Console.ReadLine();

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(product) && product.Length > 2)
                {
                    var result = Helpers.CapitalizeFirstLetter(product);

                    try
                    {
                        using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath, true))
                        {
                            outputFile.WriteLine(result.Trim());
                        }

                        Console.WriteLine("Product saved.");
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while saving products: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Product cannot be empty, please insert a valid product:");
                }
            }
        }

        internal void DeleteProduct()
        {
            if (_products?.ProductsList.Count > 0)
            {
                Console.WriteLine("Enter the product id:");

                while (true)

                {
                    foreach (KeyValuePair<int, string> product in _products.ProductsList)
                    {
                        Console.WriteLine($"{product.Key}: {product.Value}");
                    }

                    var indexProduct = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(indexProduct))
                    {
                        try
                        {
                            if (_products.ProductsList.ContainsKey(int.Parse(indexProduct)))
                            {
                                _products.ProductsList.Remove(int.Parse(indexProduct));
                                Console.WriteLine("Product removed successfully.");
                                return;
                            }

                            Console.WriteLine("Product id not found, please insert a valid id:");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Product id not found, please insert a valid id:");
                        }
                    }
                }
            }

            Console.WriteLine(EmptyProductList);
        }

        internal void UpdateProduct()
        {
            if (_products?.ProductsList.Count > 0)
            {
                Console.WriteLine("Enter the product id:");

                while (true)
                {
                    foreach (KeyValuePair<int, string> product in _products.ProductsList)
                    {
                        Console.WriteLine($"{product.Key}: {product.Value}");
                    }

                    var productIndex = Console.ReadLine();

                    try
                    {
                        if (_products.ProductsList.ContainsKey(int.Parse(productIndex)))
                        {
                            Console.WriteLine("Enter the new product name:");
                            var newProductName = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(newProductName) && newProductName.Length > 2)
                            {
                                var result = Helpers.CapitalizeFirstLetter(newProductName);

                                if (!_products.ProductsList.ContainsValue(result))
                                {
                                    _products.ProductsList[int.Parse(productIndex)] = result;
                                    Console.WriteLine("Product added successfully.");
                                    return;
                                }

                                Console.WriteLine("Product already exists. please insert a different product:");
                            }
                            else
                            {
                                Console.WriteLine("Product cannot be empty, please insert a valid product:");
                            }

                        }

                        Console.WriteLine("Product id not found, please insert a valid id:");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product id not found, please insert a valid id:");
                    }
                }
            }

            Console.WriteLine(EmptyProductList);
        }
    }
}
