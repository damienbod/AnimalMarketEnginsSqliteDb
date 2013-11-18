using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMarketCommon.Attributes;
using AnimalMarketDal.DomainModel;
using AnimalMarketDal.Repo;
using AnimalMarketEngine.Engine;

namespace AnimalMarketEngine.DataAccess
{
    [LifecycleSingleton]
    public class EventListData : IEventListData
    {
        private readonly IEventDataRepository _eventDataRepository;

        public EventListData(IEventDataRepository eventDataRepository)
        {
            _eventDataRepository = eventDataRepository;

            _pigEventData = _eventDataRepository.GetPigData().ToList();
            _calfEventData = _eventDataRepository.GetCalfData().ToList();
            _lambEventData = _eventDataRepository.GetLambData().ToList();

        }

        private readonly List<EventData> _pigEventData = new List<EventData>();
        private readonly List<EventData> _calfEventData = new List<EventData>();
        private readonly List<EventData> _lambEventData = new List<EventData>();

        public EventData GetPigEvent()
        {
            return _pigEventData[ThreadLocalRandom.Next(1, _pigEventData.Count) - 1];
        }

        public EventData GetLambEvent()
        {
            return _lambEventData[ThreadLocalRandom.Next(1, _lambEventData.Count) - 1];
        }

        public EventData GetCalfEvent()
        {
            return _calfEventData[ThreadLocalRandom.Next(1, _calfEventData.Count) - 1];
        }

        public AnimalType GetCowType()
        {
            return _eventDataRepository.GetCowType();
        }

        public AnimalType GetPigType()
        {
            return _eventDataRepository.GetPigType();
        }

        public AnimalType GetLambType()
        {
            return _eventDataRepository.GetLambType();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _eventDataRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}