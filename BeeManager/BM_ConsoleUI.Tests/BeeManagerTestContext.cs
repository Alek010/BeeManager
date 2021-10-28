using BeeManagerLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeeManagerLibrary.Tests
{
    public class BeeManagerTestContext : IDisposable
    {
        public BeeManagerContext BeeManagerTestDb { get; private set; }

        public BeeManagerTestContext()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<BeeManagerContext>()
                .UseInMemoryDatabase(myDatabaseName)
                .Options;

            BeeManagerTestDb = new BeeManagerContext(options);

            BeeManagerTestDb.Production.AddRange(
                    new Production() { Id = 1, Date = new DateTime(2019, 9, 30), ProductId = 1, Quantity = 21.5, UnitsOfMeasurementId = 1 },
                    new Production() { Id = 2, Date = new DateTime(2020, 10, 16), ProductId = 2, Quantity = 3, UnitsOfMeasurementId = 2 },
                    new Production() { Id = 3, Date = new DateTime(2020, 3, 20), ProductId = 3, Quantity = 1, UnitsOfMeasurementId = 3 },
                    new Production() { Id = 4, Date = new DateTime(2020, 7, 4), ProductId = 1, Quantity = 32, UnitsOfMeasurementId = 1 },
                    new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 },
                    new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 });

            BeeManagerTestDb.Products.AddRange(
                    new Product() { Id = 1, Name = "Medus" },
                    new Product() { Id = 2, Name = "Šūnu medus" },
                    new Product() { Id = 3, Name = "Vasks" },
                    new Product() { Id = 4, Name = "Ziedputekšņi" });

            BeeManagerTestDb.UnitsOfMeasurements.AddRange(
                    new UnitsOfMeasurement() { Id = 1, Unit = "Litrs" },
                    new UnitsOfMeasurement() { Id = 2, Unit = "Gabals" },
                    new UnitsOfMeasurement() { Id = 3, Unit = "Kilograms" },
                    new UnitsOfMeasurement() { Id = 4, Unit = "Grams" },
                    new UnitsOfMeasurement() { Id = 5, Unit = "Iepakojums" });
            BeeManagerTestDb.SaveChanges();
        }

        public void Dispose()
        {
            BeeManagerTestDb.Dispose();
        }
    }
}
