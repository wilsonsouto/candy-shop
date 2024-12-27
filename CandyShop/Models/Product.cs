namespace CandyShop.Models
{
    internal class Product
    {
        internal string Name { get; set; }

        internal int Id { get; }

        internal decimal Price { get; set; }

        public Product(int id)
        {
            Id = id;
        }
    }
}
