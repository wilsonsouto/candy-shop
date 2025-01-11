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

                string checkTableExistsQuery = @"
                    SELECT COUNT(*)
                    FROM information_schema.tables
                    WHERE table_schema = DATABASE() AND table_name = 'Product';";

                using var checkCommand = new MySqlCommand(checkTableExistsQuery, connection);
                bool tableExists = Convert.ToInt32(checkCommand.ExecuteScalar()) > 0;

                if (!tableExists)
                {
                    string createTableQuery = @"
                        CREATE TABLE Product (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(20) NOT NULL,
                        Price DECIMAL(10, 2) NOT NULL,
                        CocoaPercentage INT NULL,
                        Shape VARCHAR(20) NULL,
                        Type INT NOT NULL
                    );";

                    using var createCommand = new MySqlCommand(createTableQuery, connection);
                    createCommand.ExecuteNonQuery();

                    Console.WriteLine("Table 'Product' created successfully.\n");
                }
                else
                {
                    Console.WriteLine("Table 'Product' already exists.\n");
                }
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
                using var connection = new MySqlConnection(ConnectionString);
                connection.Open();

                using var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = "SELECT * FROM Product";

                using var reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(5) == (int)ProductType.ChocolateBar)
                        {

                            products.Add(new ChocolateBar(reader.GetInt32(0))
                            {
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                CocoaPercentage = reader.GetInt32(3),
                            });
                        }
                        else
                        {
                            products.Add(new Lollipop(reader.GetInt32(0))
                            {
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Shape = reader.GetString(4),
                            });
                        }
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
