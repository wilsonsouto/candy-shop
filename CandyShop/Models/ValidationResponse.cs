namespace CandyShop.Models
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; } = "";
    }

    public class CocoaValidationResponse : ValidationResponse
    {
        public int CocoaPercentage { get; set; }
    }

    public class PriceValidationResponse : ValidationResponse
    {
        public decimal Price { get; set; }
    }
}
