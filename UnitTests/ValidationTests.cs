using CandyShop.Helpers;

namespace UnitTests;

public class ValidationTests
{
    [Fact]
    public void WhenStringIsValidReturnTrue()
    {
        var input = "Kitkat";
        var result = ValidationHelper.IsStringValid(input);

        Assert.True(result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Ki")]
    [InlineData("This string has more than 20 characters")]
    public void WhenStringIsNotValidReturnFalse(string testString)
    {
        var result = ValidationHelper.IsStringValid(testString);
        Assert.False(result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("-1")]
    [InlineData("1000")]
    public void WhenPriceIsNotValidReturnFalse(string testString)
    {
        var result = ValidationHelper.IsPriceValid(testString);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("-1")]
    [InlineData("1000")]
    public void WhenCocoaIsNotValidReturnFalse(string testString)
    {
        var result = ValidationHelper.IsCocoaValid(testString);
        Assert.False(result.IsValid);
    }
}
