using CandyShop.Enums;

namespace CandyShop.Models
{
    internal class Lollipop : Product
    {
        internal string _shape { get; set; } = "";

        internal string Shape
        {
            get => _shape;
            set => _shape = Helpers.ProductHelper.CapitalizeFirstLetter(value);
        }

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
