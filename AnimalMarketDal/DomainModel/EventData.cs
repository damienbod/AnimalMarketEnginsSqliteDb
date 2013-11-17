namespace AnimalMarketDal.DomainModel
{
    public class EventData
    {
        public long EventDataId { get; set; }
        public int Factor { get; set; }
        public string StringTestId { get; set; }
        public double FixChange { get; set; }

        public long AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }
    }
}