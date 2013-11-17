using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using AnimalMarketCommon.Attributes;
using AnimalMarketDal.Dal;

namespace AnimalMarketDal.Repo
{
    [LifecycleTransient]
    public class EventDataRepository : IEventDataRepository
    {
        private readonly AnimalContext _context;

        public EventDataRepository(AnimalContext context)
        {
            _context = context;
        }

        public void GetAnimalTypes()
        {
            var animals = from a in _context.AnimalTypes
                          //where a.StringTestId.StartsWith("P")
                          //orderby a.StringTestId
                          select a;

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
            }
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
