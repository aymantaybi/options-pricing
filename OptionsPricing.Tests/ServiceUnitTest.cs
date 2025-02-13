using Xunit;
using OptionsPricing.Models;
using OptionsPricing.Services;

namespace OptionsPricing.Tests.Services
{
    public class OptionsPricingServiceTests
    {
        [Fact]
        public void CalculateOptionPrice_CallOption_ReturnsCorrectPrice()
        {
            var option = new Option
            {
                StockPrice = 100,
                StrikePrice = 100,
                TimeToMaturity = 1,
                RiskFreeRate = 0.05,
                Volatility = 0.2,
                OptionType = "Call"
            };

            var service = new Pricing();
            double price = service.CalculateOptionPrice(option);

            Assert.True(price > 0, "Call option price should be greater than 0.");
        }

        [Fact]
        public void CalculateOptionPrice_PutOption_ReturnsCorrectPrice()
        {
            var option = new Option
            {
                StockPrice = 100,
                StrikePrice = 100,
                TimeToMaturity = 1,
                RiskFreeRate = 0.05,
                Volatility = 0.2,
                OptionType = "Put"
            };

            var service = new Pricing();
            double price = service.CalculateOptionPrice(option);

            Assert.True(price > 0, "Put option price should be greater than 0.");
        }
    }
}