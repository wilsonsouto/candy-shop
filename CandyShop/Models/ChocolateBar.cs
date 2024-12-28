using CandyShop.Enums;

namespace CandyShop.Models
{
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

        internal override string GetProductForPanel()
        {
            return $@"
Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Cocoa percentage: {CocoaPercentage}";
        }
    }
}
