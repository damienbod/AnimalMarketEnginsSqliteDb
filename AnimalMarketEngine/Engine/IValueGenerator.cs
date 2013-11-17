namespace AnimalMarketEngine.Engine
{
    public interface IValueGenerator
    {
        double GetNextValue(double isValue, int maxChangeinProzent, double fixChange, double meanValueBegin);
    }
}
