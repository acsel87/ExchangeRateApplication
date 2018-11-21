using System;
using System.Collections.Generic;
using System.Linq;

namespace ER_Library.Helpers
{
    public static class ChartRateRange
    {
        public static void GetMinMax(this List<decimal> rates, out decimal min, out decimal max)
        {
            decimal ratesMin = rates.Min();
            decimal ratesMax = rates.Max();

            int decimalsNumber = CountRoundingPoint(ratesMax - ratesMin) - 1;

            if (decimalsNumber < 0)
            {
                decimalsNumber = 0;
            }

            min = Math.Floor(ratesMin * (decimal)Math.Pow(10, decimalsNumber)) / (decimal)Math.Pow(10, decimalsNumber);
            max = Math.Ceiling(ratesMax * (decimal)Math.Pow(10, decimalsNumber)) / (decimal)Math.Pow(10, decimalsNumber);
        }

        public static int CountRoundingPoint(decimal d)
        {
            d -= Math.Floor(d);

            int decimalsNumber = 0;

            while (d < 1 && d != 0)
            {
                decimalsNumber++;
                d *= 10;
            }

            return decimalsNumber;
        }
    }
}
