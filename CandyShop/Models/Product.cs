namespace CandyShop.Models
{
    internal class Product
    {
        internal int Id { get; set; }

        private string _name = "";

        internal string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3 characters long.");
                }

                var capitalizedName = Helpers.CapitalizeFirstLetter(value);
                _name = capitalizedName;
            }
        }

        private decimal _price;

        internal decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                _price = value;
            }
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
}
