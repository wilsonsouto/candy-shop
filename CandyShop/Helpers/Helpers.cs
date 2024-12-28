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

        internal static string GetValidatedInput(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(input) && input.Length < 3)
                            throw new ArgumentException(errorMessage);

                        return CapitalizeFirstLetter(input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        internal static decimal GetValidatedNumber(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(input) || !decimal.TryParse(input, out var result) || result <= 0)
                    {
                        throw new ArgumentException(errorMessage);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string CapitalizeFirstLetter(string product)
        {
            return char.ToUpper(product[0]) + product.Substring(1).ToLower();
        }
    }
}
