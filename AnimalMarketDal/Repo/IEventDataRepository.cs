using System;
using System.Collections.Generic;
using AnimalMarketDal.DomainModel;

namespace AnimalMarketDal.Repo
{
    public interface IEventDataRepository : IDisposable
    {
        AnimalType GetCowType();

        AnimalType GetPigType();

        AnimalType GetLambType();

        IEnumerable<EventData> GetPigData();

        IEnumerable<EventData> GetLambData();

        IEnumerable<EventData> GetCalfData();
    }
}
