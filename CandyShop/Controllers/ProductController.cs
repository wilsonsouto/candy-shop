using CandyShop.Enums;
using CandyShop.Models;
using MySqlConnector;

namespace CandyShop.Controllers
{
    internal class ProductController
    {
        private const string ConnectionString = "Server=localhost;Database=CandyShop;User=root;Password=1234;";

        internal void CreateDatabase()
        {
            using var connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Database connection established.");

                // SQL query to create the Product table
                string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Product (
            Id INT AUTO_INCREMENT PRIMARY KEY,
            Name VARCHAR(20) NOT NULL,
            Price DECIMAL(10, 2) NOT NULL,
            CocoaPercentage INT NULL,
            Shape VARCHAR(20) NULL,
            Type INT NOT NULL
        );";

                using var command = new MySqlCommand(createTableQuery, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Table 'Product' created successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating the table: {ex.Message}\n");
            }
        }

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
                        }
                        else
                        {
                            var product = new Lollipop(int.Parse(parts[0]));
                            product.Name = parts[2].Trim();
                            product.Price = decimal.Parse(parts[3].Trim());
                            product.Shape = parts[5].Trim();
                            products.Add(product);
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
            try
            {
                using var connection = new MySqlConnection(ConnectionString);
                connection.Open();

                using var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = product.GetInsertQuery();
                product.AddParameters(tableCmd);

                tableCmd.ExecuteNonQuery();

                Console.WriteLine("Product saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving products: " + ex.Message);
            }
        }

        internal void AddProducts(List<Product> products)
        {
            try
            {

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving products: " + ex.Message);
            }
        }

        internal void DeleteProduct(Product product)
        {
            var products = GetProducts();
            var updatedProducts = products.Where(p => p.Id != product.Id).ToList();

            AddProducts(updatedProducts);

            Console.WriteLine("Product deleted.");
        }

        internal void UpdateProduct(Product product)
        {
            var products = GetProducts();

            var updatedProducts = products
                .Where(p => p.Id != product.Id) // Filter out the product with the same Id
                .Concat([product]) // Add the updated product
                .OrderBy(p => p.Id) // Sort by Id
                .ToList();

            AddProducts(updatedProducts);

            Console.WriteLine("Product updated.");
        }
    }
}
