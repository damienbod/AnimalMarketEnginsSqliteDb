using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMarketCommon.Attributes;
using AnimalMarketDal.Dal;
using AnimalMarketDal.DomainModel;

namespace AnimalMarketDal.Repo
{
    [LifecycleTransient]
    public class EventDataRepository : IEventDataRepository
    {
        private const int PigId = 1;
        private const int CalfId = 2;
        private const int LambId = 0;

        private readonly AnimalContext _context;

        public EventDataRepository(AnimalContext context)
        {
            _context = context;
        }

        private IEnumerable<AnimalType> GetAnimalTypes()
        {
            return from a in _context.AnimalTypes select a;
        }

        public AnimalType GetCowType()
        {
            return GetAnimalTypes().FirstOrDefault(a => a.Id.Equals(CalfId));
        }

        public AnimalType GetPigType()
        {
            return GetAnimalTypes().FirstOrDefault(a => a.Id.Equals(PigId));
        }

        public AnimalType GetLambType()
        {
            return GetAnimalTypes().FirstOrDefault(a => a.Id.Equals(LambId));
        }

        public IEnumerable<EventData> GetPigData()
        {
            return from a in _context.EventDataValues
                   where a.AnimalTypeId.Equals(PigId)
                          orderby a.StringTestId
                          select a;
        }

        public IEnumerable<EventData> GetLambData()
        {
            return from a in _context.EventDataValues
                   where a.AnimalTypeId.Equals(LambId)
                   orderby a.StringTestId
                   select a;
        }

        public IEnumerable<EventData> GetCalfData()
        {
            return from a in _context.EventDataValues
                   where a.AnimalTypeId.Equals(CalfId)
                   orderby a.StringTestId
                   select a;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
