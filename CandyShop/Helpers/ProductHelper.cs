namespace CandyShop.Helpers
{
    public static class ProductHelper
    {
        public static int GetDaysSinceOpening()
        {
            var openingDate = new DateTime(1997, 1, 25);
            TimeSpan timeDifference = DateTime.Now - openingDate;

            return timeDifference.Days;
        }

        public static string CapitalizeFirstLetter(string product)
        {
            return char.ToUpper(product[0]) + product[1..].ToLower();
        }
    }
}
