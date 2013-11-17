using System;

namespace AnimalMarketDal.Repo
{
    public interface IEventDataRepository : IDisposable
    {
        void GetAnimalTypes();
    }
}
