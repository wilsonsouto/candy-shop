namespace CandyShop.Models
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }

        internal string ErrorMessage { get; set; } = "";
    }

    public class CocoaValidationResponse : ValidationResponse
    {
        internal int CocoaPercentage { get; set; }
    }

    public class PriceValidationResponse : ValidationResponse
    {
        internal decimal Price { get; set; }
    }
}
