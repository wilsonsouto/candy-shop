using CandyShop.Models;
using static CandyShop.Enums;

namespace CandyShop.Controllers
{
    internal class ProductController
    {
        internal List<Product> GetProducts()
        {
            var products = new List<Product>();

            try
            {
                using (StreamReader reader = new StreamReader(Configuration.DocPath, true))
                {
                    reader.ReadLine(); // discard first line
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        if (int.Parse(parts[1]) == (int)ProductType.ChocolateBar)
                        {
                            var product = new ChocolateBar(int.Parse(parts[0]));
                            product.Name = parts[2].Trim();
                            product.Price = decimal.Parse(parts[3].Trim());
                            product.CocoaPercentage = int.Parse(parts[4].Trim());
                            products.Add(product);

                            // if (!products.Any(p => p.Id == product.Id))
                            // {
                            //     products.Add(product);
                            // }
                        }
                        else
                        {
                            var product = new Lollipop(int.Parse(parts[0]));
                            product.Name = parts[2].Trim();
                            product.Price = decimal.Parse(parts[3].Trim());
                            product.Shape = parts[5].Trim();
                            products.Add(product);

                            // if (!products.Any(p => p.Id == product.Id))
                            // {
                            //     products.Add(product);
                            // }
                        }

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

        internal void AddProduct(Product product)
        {
            var id = GetProducts().Count;

            try
            {
                using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath, true))
                {
                    if (outputFile.BaseStream.Length <= 3)
                    {
                        outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
                    }

                    var csvLine = product.GetProductsForCsv(id);
                    outputFile.WriteLine(csvLine);
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
