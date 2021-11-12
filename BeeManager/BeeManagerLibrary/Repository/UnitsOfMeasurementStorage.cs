using BeeManagerLibrary.Exceptions;
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
            var unit = _beeManagerContext.UnitsOfMeasurements.SingleOrDefault(p => p.Id == id);

            if (unit == null)
            {
                throw new MeasurementUnitNotFoundException($"Measurement unit with ID number: {id} not found");
            }

            return unit;
        }

        public void DeleteUnitById(int id)
        {
            var unit = GetUnitById(id);

            if (unit == null)
            {
                throw new MeasurementUnitNotFoundException($"Measurement unit with ID number: {id} not found");
            }

            _beeManagerContext.UnitsOfMeasurements.Remove(unit);

            _beeManagerContext.SaveChanges();
        }

        public void AddUnit(string unitName)
        {
            if (string.IsNullOrWhiteSpace(unitName))
            {
                throw new MeasurementUnitNameIsNullOrWhiteSpaceException($"Entered string of measurement unit is null, empty or white space");
            }

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

            if (unit == null)
            {
                throw new MeasurementUnitNotFoundException($"Measurement unit with ID number: {id} not found");
            }

            if (string.IsNullOrWhiteSpace(unit.Unit))
            {
                throw new MeasurementUnitNameIsNullOrWhiteSpaceException($"Entered string of measurement unit is null, empty or white space");
            }

            _beeManagerContext.Update(unit);

            _beeManagerContext.SaveChanges();
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            return _beeManagerContext.UnitsOfMeasurements.ToList();
        }
    }
}
