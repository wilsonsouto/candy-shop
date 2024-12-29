using CandyShop.Enums;

namespace CandyShop.Models
{
    internal abstract class Product
    {
        internal int Id { get; set; }

        private string _name = "";

        internal string Name
        {
            get => _name;
            set => _name = Helpers.ProductHelper.CapitalizeFirstLetter(value);
        }

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
