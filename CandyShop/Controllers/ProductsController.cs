using CandyShop.Models;

namespace CandyShop.Controllers
{
    internal class ProductsController
    {
        private readonly Products _products = new Products();

        private const string EmptyProductList = "The product list is empty.";
        
        internal void ViewProducts()
        {
            if (_products?.ProductsList.Count > 0)
            {
                var productsCount = _products.ProductsList.Count == 1 ? $"The product list contains {_products.ProductsList.Count} product." : $"The product list contains {_products.ProductsList.Count} _products.ProductsList.";
                Console.WriteLine(productsCount);

                foreach (KeyValuePair<int, string> product in _products.ProductsList)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
                return;
            }

            Console.WriteLine(EmptyProductList);
        }

        internal void AddProduct()
        {
            Console.WriteLine("Enter the product name:");

            while (true)
            {
                var product = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(product) && product.Length > 2)
                {
                    var result = Helpers.CapitalizeFirstLetter(product);

                    if (!_products.ProductsList.ContainsValue(result))
                    {
                        int newKey = _products.ProductsList.Count > 0 ? _products.ProductsList.Keys.Max() + 1 : 1;
                        _products.ProductsList.TryAdd(newKey, result);
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

        internal void SaveProducts()
        {
            try
            {
                if (_products?.ProductsList.Count > 0)
                {
                    using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath))
                    {
                        foreach (KeyValuePair<int, string> product in _products.ProductsList)
                        {
                            outputFile.WriteLine($"{product.Key},{product.Value}");
                        }

                        Console.WriteLine("Products saved.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving products: " + ex.Message);
            }
        }

        internal void LoadData()
        {
            try
            {
                using (StreamReader reader = new(Configuration.DocPath))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');
                        _products?.ProductsList.Add(int.Parse(parts[0]), parts[1]);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading products: " + ex.Message);
            }
        }
    }
}
