
namespace CandyShop.Models
{
    internal class Product
    {
        private string _name { get; set; } = "";

        internal string Name
        {
            get
            {
                return _name;
            }

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

                var result = Helpers.CapitalizeFirstLetter(value);
                _name = result;
            }
        }

        internal int Id { get; set; }

        internal decimal Price { get; set; }
    }
}
