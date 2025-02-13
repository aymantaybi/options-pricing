namespace OptionsPricing.Models
{
    public class Option
    {
        public double StockPrice { get; set; }      
        public double StrikePrice { get; set; }     
        public double TimeToMaturity { get; set; } 
        public double RiskFreeRate { get; set; }     
        public double Volatility { get; set; }      
        public string OptionType { get; set; }       // todo use enum
    }
}