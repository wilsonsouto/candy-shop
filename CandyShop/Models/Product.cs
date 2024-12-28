using CandyShop.Enums;

namespace CandyShop.Models
{
    internal abstract class Product
    {
        internal int Id { get; set; }

        internal string Name { get; set; } = "";

        internal decimal Price { get; set; }

        internal ProductType Type { get; set; }

        internal Product() { }

        internal Product(int id)
        {
            Id = id;
        }

        internal Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        internal abstract string GetProductsForCsv(int id);

        internal abstract string GetProductForPanel();
    }
}
