using CandyShop.Enums;

namespace CandyShop.Models
{
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

        internal override string GetProductForPanel()
        {
            return $@"
Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Shape: {Shape}";
        }
    }
}
