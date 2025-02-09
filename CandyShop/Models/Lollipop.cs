using CandyShop.Enums;
using MySqlConnector;

namespace CandyShop.Models;

public class Lollipop : Product
{
    private string _shape { get; set; } = "";

    public string Shape
    {
        get => _shape;
        set => _shape = Helpers.ProductHelper.CapitalizeFirstLetter(value);
    }

    public Lollipop()
    {
        Type = ProductType.Lollipop;
    }

    public Lollipop(int id)
        : base(id)
    {
        Type = ProductType.Lollipop;
    }

    public override string GetProductsForCsv(int id)
    {
        return $"{id},{(int)Type},{Name},{Price},,{Shape}";
    }

    public override string GetProductForPanel()
    {
        return $@"
Id: {Id}
Type: {Type}
Name: {Name}
Price: {Price}
Shape: {Shape}";
    }

    public override string GetInsertQuery()
    {
        return $@"INSERT INTO Product (name, price, type, shape) VALUES (@Name, @Price, @Type, @Shape)";
    }

    public override void AddParameters(MySqlCommand cmd)
    {
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Price", Price);
        cmd.Parameters.AddWithValue("@Type", (int)Type);
        cmd.Parameters.AddWithValue("@Shape", Shape);
    }

    public override string GetUpdateQuery()
    {
        return $@"UPDATE Product SET name = @Name, price = @Price, type = 1, shape = @Shape WHERE Id = {Id}";
    }
}
