using CandyShop.Enums;
using MySqlConnector;

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

        internal override string GetInsertQuery()
        {
            return $@"INSERT INTO Product (name, price, type, cocoaPercentage) VALUES (@Name, @Price, @Type, @CocoaPercentage)";
        }

        internal override void AddParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Type", (int)Type);
            cmd.Parameters.AddWithValue("@CocoaPercentage", CocoaPercentage);
        }
    }
}
