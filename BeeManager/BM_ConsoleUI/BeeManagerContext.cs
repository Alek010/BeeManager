using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BM_ConsoleUI
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
    }
}
