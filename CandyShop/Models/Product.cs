using static CandyShop.Enums;

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
    }

    internal class ChocolateBar : Product
    {
        internal int CocoaPercentage { get; set; }

        internal ChocolateBar()
        {
            Type = ProductType.ChocolateBar;
        }

        internal ChocolateBar(int id)
            : base(id)
        {
            Type = ProductType.ChocolateBar;
        }

        internal override string GetProductsForCsv(int id)
        {
            return $"{id},{(int)Type},{Name},{Price},{CocoaPercentage}";
        }
    }

    internal class Lollipop : Product
    {
        internal string Shape { get; set; } = "";

        internal Lollipop()
        {
            Type = ProductType.Lollipop;
        }

        internal Lollipop(int id)
            : base(id)
        {
            Type = ProductType.Lollipop;
        }

        internal override string GetProductsForCsv(int id)
        {
            return $"{id},{(int)Type},{Name},{Price},,{Shape}";
        }
    }
}
