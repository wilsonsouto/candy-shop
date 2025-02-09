namespace CandyShop.Helpers;

internal static class ProductHelper
{
    internal static int GetDaysSinceOpening()
    {
        DateTime openingDate = new DateTime(1997, 1, 25);
        TimeSpan timeDifference = DateTime.Now - openingDate;

        return timeDifference.Days;
    }

    internal static string CapitalizeFirstLetter(string product)
    {
        return char.ToUpper(product[0]) + product[1..].ToLower();
    }
}
