using CandyShop.Enums;
using CandyShop.Helpers;
using MySqlConnector;

namespace CandyShop.Models
{
    public abstract class Product
    {
        public int Id { get; set; }

        private string _name = "";

        public string Name
        {
            get => _name;
            set
            {
                _name = ProductHelper.CapitalizeFirstLetter(value);
            }
        }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        public Product() { }

        public Product(int id)
        {
            Id = id;
        }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public abstract string GetProductsForCsv(int id);

        public abstract string GetProductForPanel();

        public abstract string GetInsertQuery();

        public abstract string GetUpdateQuery();

        public abstract void AddParameters(MySqlCommand cmd);
    }
}
