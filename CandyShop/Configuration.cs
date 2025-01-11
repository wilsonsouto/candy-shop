namespace CandyShop
{
    internal static class Configuration
    {
        internal static string DocPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Products.csv");
    }
}
