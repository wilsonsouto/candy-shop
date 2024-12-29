using CandyShop.Models;

namespace CandyShop.Helpers
{
    public class ValidationHelper
    {
        public static bool IsStringValid(string? input)
        {
            return !string.IsNullOrEmpty(input) && input.Length >= 3;
        }

        public static PriceValidationResponse IsPriceValid(string? input)
        {
            var response = new PriceValidationResponse { IsValid = true };

            decimal price;

            if (!decimal.TryParse(input, out price))
            {
                response.IsValid = false;
                response.ErrorMessage = "Not a valid number. Try again: ";
            }

            if (price < 0 || price > 999)
            {
                response.IsValid = false;
                response.ErrorMessage = "Price must be between 0 and 999. Try again: ";
            }

            response.Price = price;

            return response;
        }

        public static CocoaValidationResponse IsCocoaValid(string? input)
        {
            var response = new CocoaValidationResponse { IsValid = true };

            int percentage;

            if (!int.TryParse(input, out percentage))
            {
                response.IsValid = false;
                response.ErrorMessage = "Not a valid number. Try again: ";
            }

            if (percentage < 0 || percentage > 100)
            {
                response.IsValid = false;
                response.ErrorMessage = "Cocoa percentage must be between 0 and 100. Try again: ";
            }

            response.CocoaPercentage = percentage;

            return response;
        }
    }
}
