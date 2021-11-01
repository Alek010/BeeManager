using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Repository
{
    public interface IUnitsOfMeasurementStorage
    {
        void AddUnit(string unitName);
        void DeleteUnitById(int id);
        UnitsOfMeasurement GetUnitById(int id);
        List<UnitsOfMeasurement> GetUnitsList();
        void UpdateUnit(int id, string unitName);
    }
}