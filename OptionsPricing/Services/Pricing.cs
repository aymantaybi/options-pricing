using System;
using OptionsPricing.Models;

namespace OptionsPricing.Services
{
    public class Pricing
    {
        public double CalculateOptionPrice(Option option)
        {
            double d1 = (Math.Log(option.StockPrice / option.StrikePrice) + 
                        (option.RiskFreeRate + Math.Pow(option.Volatility, 2) / 2) * option.TimeToMaturity) /
                       (option.Volatility * Math.Sqrt(option.TimeToMaturity));

            double d2 = d1 - option.Volatility * Math.Sqrt(option.TimeToMaturity);

            if (option.OptionType == "Call")
            {
                return option.StockPrice * CumulativeDistribution(d1) -
                       option.StrikePrice * Math.Exp(-option.RiskFreeRate * option.TimeToMaturity) * CumulativeDistribution(d2);
            }
            else if (option.OptionType == "Put")
            {
                return option.StrikePrice * Math.Exp(-option.RiskFreeRate * option.TimeToMaturity) * CumulativeDistribution(-d2) -
                       option.StockPrice * CumulativeDistribution(-d1);
            }
            else
            {
                throw new ArgumentException("Invalid option type. Use 'Call' or 'Put'.");
            }
        }

        private double CumulativeDistribution(double x)
        {
           
            double a1 = 0.31938153;
            double a2 = -0.356563782;
            double a3 = 1.781477937;
            double a4 = -1.821255978;
            double a5 = 1.330274429;
            double l = Math.Abs(x);
            double k = 1.0 / (1.0 + 0.2316419 * l);
            double w = 1.0 - 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-l * l / 2.0) * 
                      (a1 * k + a2 * k * k + a3 * Math.Pow(k, 3) + a4 * Math.Pow(k, 4) + a5 * Math.Pow(k, 5));

            if (x < 0.0)
            {
                return 1.0 - w;
            }
            return w;
        }
    }
}