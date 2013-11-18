using System;
using AnimalMarketDal.DomainModel;

namespace AnimalMarketEngine.DataAccess
{
    public interface IEventListData : IDisposable
    {
        EventData GetPigEvent();

        EventData GetLambEvent();

        EventData GetCalfEvent();

        AnimalType GetCowType();

        AnimalType GetPigType();

        AnimalType GetLambType();
    }
}
