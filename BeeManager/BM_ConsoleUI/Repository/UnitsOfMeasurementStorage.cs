using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class UnitsOfMeasurementStorage : IUnitsOfMeasurementStorage
    {
        private BeeManagerContext _beeManagerContext;
        public UnitsOfMeasurementStorage()
        {
            _beeManagerContext = new BeeManagerContext(BeeManagerContext.GetDbContextOptions());
        }

        public UnitsOfMeasurementStorage(BeeManagerContext beeManagerContext)
        {
            _beeManagerContext = beeManagerContext;
        }

        public UnitsOfMeasurement GetUnitById(int id)
        {
            return _beeManagerContext.UnitsOfMeasurements.SingleOrDefault(p => p.Id == id);
        }

        public void DeleteUnitById(int id)
        {
            var product = GetUnitById(id);
            _beeManagerContext.UnitsOfMeasurements.Remove(product);

            _beeManagerContext.SaveChanges();
        }

        public void AddUnit(string unitName)
        {
            _beeManagerContext.Add(new UnitsOfMeasurement()
            {
                Unit = unitName
            });
            _beeManagerContext.SaveChanges();
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            return _beeManagerContext.UnitsOfMeasurements.ToList();
        }
    }
}
