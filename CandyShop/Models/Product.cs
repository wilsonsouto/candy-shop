using static CandyShop.Enums;

namespace CandyShop.Models
{
    internal class Product
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

        public override string ToString()
        {
            return $"{Id}, {Name}, {Price}";
        }
    }

    internal class ChocolateBar : Product
    {
        internal int CocoaPercentage { get; set; }

        internal ChocolateBar() { }

        internal ChocolateBar(int id)
            : base(id)
        {
            Type = ProductType.ChocolateBar;
        }
    }

    internal class Lollipop : Product
    {
        internal string Shape { get; set; } = "";

        internal Lollipop() { }

        internal Lollipop(int id)
            : base(id)
        {
            Type = ProductType.Lollipop;
        }
    }
}
