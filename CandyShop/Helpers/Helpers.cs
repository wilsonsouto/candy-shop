namespace CandyShop.Helpers
{
    internal static class ProductHelpers
    {
        internal static int GetDaysSinceOpening()
        {
            DateTime openingDate = new DateTime(1997, 1, 25);
            TimeSpan timeDifference = DateTime.Now - openingDate;

            return timeDifference.Days;
        }

        internal static string CapitalizeFirstLetter(string product)
        {
            return char.ToUpper(product[0]) + product.Substring(1).ToLower();
        }
    }
}
