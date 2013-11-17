using System;
using AnimalMarketCommon.Attributes;

namespace AnimalMarketEngine.Engine
{
    [LifecycleSingleton]
    public class ValueGenerator : IValueGenerator
    {
        public double GetNextValue(double isValue, int maxChangeinProzent, double fixChange, double meanValueBegin)
        {
            int rand = ThreadLocalRandom.Next(0, 100);

            isValue = ResetValue10ProzentRule(isValue, meanValueBegin);
            isValue = isValue + ((isValue * fixChange )/ 100);
            return Math.Ceiling(isValue + ((isValue * maxChangeinProzent * rand) / 10000));
        }

        private double ResetValue10ProzentRule(double isValue,  double meanValueBegin)
        {
            // Data leak protection
            double test = isValue/meanValueBegin;
            if (test > 2)
            {
                return meanValueBegin;
            }
            if (test < 0.25)
            {
                return meanValueBegin;
            }

            int rand = ThreadLocalRandom.Next(0, 10);
            if (rand == 3)
            {
                return meanValueBegin;
            }

            return isValue;
        }
    }
}