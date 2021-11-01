using BeeManagerLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Repository
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
            var unit = GetUnitById(id);
            _beeManagerContext.UnitsOfMeasurements.Remove(unit);

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

        public void UpdateUnit(int id, string unitName)
        {
            var unit = GetUnitById(id);
            unit.Unit = unitName;

            _beeManagerContext.Update(unit);

            _beeManagerContext.SaveChanges();
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            return _beeManagerContext.UnitsOfMeasurements.ToList();
        }
    }
}
