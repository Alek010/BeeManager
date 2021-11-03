using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeManagerLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeManagerLibrary
{
    public class BeeManagerContext : DbContext
    {
        public BeeManagerContext(DbContextOptions<BeeManagerContext> options) 
            : base(options) 
        { }
        public DbSet<Production> Production { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitsOfMeasurement> UnitsOfMeasurements { get; set; }
        public static DbContextOptions<BeeManagerContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<BeeManagerContext>()
                .UseInMemoryDatabase(databaseName: "BeeManager")
                .Options;
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                                        .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added ||
                                                                               e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = null;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
