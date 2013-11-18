using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using AnimalMarketDal.DomainModel;

namespace AnimalMarketDal.Dal
{
    public class AnimalContext  : DbContext
    {
        public AnimalContext()
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<AnimalContext>(null);
        }

        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<EventData> EventDataValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
    }

    
}
