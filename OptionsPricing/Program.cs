using System;
using OptionsPricing.Models;
using OptionsPricing.Services;

namespace OptionsPricing
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = new Option
            {
                StockPrice = GetUserInput("current stock price: "),
                StrikePrice = GetUserInput("strike price: "),
                TimeToMaturity = GetUserInput("Time to maturity: "),
                RiskFreeRate = GetUserInput("risk-free interest rate: "),
                Volatility = GetUserInput("Volatility: "),
                OptionType = GetOptionType()
            };

            var pricingService = new Pricing();
            double price = pricingService.CalculateOptionPrice(option);

            Console.WriteLine($"The {option.OptionType} option price is: {price:C}");
        }

        private static double GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        private static string GetOptionType()
        {
            Console.Write("Enter the option type (Call/Put): ");
            string type = Console.ReadLine();
            if (type != "Call" && type != "Put")
            {
                Console.WriteLine("Invalid option type. Defaulting to 'Call'.");
                return "Call";
            }
            return type;
        }
    }
}