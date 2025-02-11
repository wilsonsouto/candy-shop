using CandyShop.Enums;
using CandyShop.Data;
using CandyShop.Models;
using MySqlConnector;

namespace CandyShop.Controllers
{
    public class ProductController : IProductController
    {
        readonly DatabaseHandler? databaseHandler;

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            try
            {
                using var connection = new MySqlConnection(databaseHandler?.ConnectionString);
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

        public void AddProduct(Product product)
        {
            try
            {
                using var connection = new MySqlConnection(databaseHandler?.ConnectionString);
                connection.Open();

                using var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = product.GetInsertQuery();
                product.AddParameters(tableCmd);

                tableCmd.ExecuteNonQuery();

                Console.WriteLine("Product saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving product: " + ex.Message);
            }
        }

        // public void AddProducts(List<Product> products)
        // {
        //     try
        //     {
        //         using (StreamWriter outputFile = new StreamWriter(Configuration.DocPath, true))
        //         {
        //             outputFile.WriteLine("Id, Type, Name, Price, CocoaPercentage, Shape");
        //             foreach (var product in products)
        //             {
        //                 var csvLine = product.GetProductsForCsv(product.Id);
        //                 outputFile.WriteLine(csvLine);
        //             }
        //         }
        //         Console.WriteLine("Product saved.");
        //         return;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("An error occurred while saving products: " + ex.Message);
        //     }
        // }

        public void DeleteProduct(Product product)
        {
            try
            {
                using var connection = new MySqlConnection(databaseHandler?.ConnectionString);
                connection.Open();

                using var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"DELETE FROM Product Where Id = {product.Id}";

                tableCmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("There was an error deleting the product: " + ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using var connection = new MySqlConnection(databaseHandler?.ConnectionString);
                connection.Open();

                using var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = product.GetUpdateQuery();
                product.AddParameters(tableCmd);

                tableCmd.ExecuteNonQuery();

                Console.WriteLine("Product updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating product: " + ex.Message);
            }
        }
    }
}
