using System;

namespace FinancialForecast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialValue = 10000;   // Starting value
            double growthRate = 0.08;      // 8% annual growth
            int years = 5;                 // Forecast for 5 years

            double futureValue = Forecast.ForecastValue(initialValue, growthRate, years);

            Console.WriteLine($"Forecasted Value after {years} years: Rs{futureValue:F2}");
        }
    }
}
