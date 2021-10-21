using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class UnitsOfMeasurementStorage : IUnitsOfMeasurementStorage
    {
        public UnitsOfMeasurement GetUnitById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.UnitsOfMeasurements.SingleOrDefault(p => p.Id == id);
            }
        }

        public void DeleteUnitById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                var product = GetUnitById(id);
                context.UnitsOfMeasurements.Remove(product);

                context.SaveChanges();
            }
        }

        public void AddUnit(string unitName)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                context.Add(new UnitsOfMeasurement()
                {
                    Unit = unitName
                });
                context.SaveChanges();
            }
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.UnitsOfMeasurements.ToList();
            }
        }
    }
}
