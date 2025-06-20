using System;

namespace FinancialForecast
{
    public class Forecast
    {
        // Recursive function to calculate future value
        public static double ForecastValue(double currentValue, double growthRate, int years)
        {
            // Base case
            if (years == 0) return currentValue;

            // Recursive case
            return ForecastValue(currentValue * (1 + growthRate), growthRate, years - 1);
        }
    }
}
