using CandyShop.Enums;
using MySqlConnector;

namespace CandyShop.Models
{
    public class ChocolateBar : Product
    {
        public int CocoaPercentage { get; set; }

        public ChocolateBar()
        {
            Type = ProductType.ChocolateBar;
        }

        public ChocolateBar(int id)
            : base(id)
        {
            Type = ProductType.ChocolateBar;
        }

        public override string GetProductsForCsv(int id)
        {
            return $"{id},{(int)Type},{Name},{Price},{CocoaPercentage}";
        }

        public override string GetProductForPanel()
        {
            return $@"
Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Cocoa percentage: {CocoaPercentage}";
        }

        public override string GetInsertQuery()
        {
            return $@"INSERT INTO Product (name, price, type, cocoaPercentage) VALUES (@Name, @Price, @Type, @CocoaPercentage)";
        }

        public override void AddParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Type", (int)Type);
            cmd.Parameters.AddWithValue("@CocoaPercentage", CocoaPercentage);
        }

        public override string GetUpdateQuery()
        {
            return $@"UPDATE Product SET name = @Name, price = @Price, type = 0, cocoaPercentage = @CocoaPercentage WHERE Id = {Id}";
        }

    }
}
