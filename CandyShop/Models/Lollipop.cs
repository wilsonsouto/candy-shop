using CandyShop.Enums;
using MySqlConnector;

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

        internal override string GetInsertQuery()
        {
            return $@"INSERT INTO Product (name, price, type, shape) VALUES (@Name, @Price, @Type, @Shape)";
        }

        internal override void AddParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Type", (int)Type);
            cmd.Parameters.AddWithValue("@Shape", Shape);
        }

        internal override string GetUpdateQuery()
        {
            return $@"UPDATE Product SET name = @Name, price = @Price, type = 1, shape = @Shape WHERE Id = {Id}";
        }
    }
}
