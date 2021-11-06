using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Services
{
    public interface IUnitsOfMeasurementServices
    {
        void AddUnit(string unitName);
        string GetUnitNameById(int id);
        void UpdateUnit(int id, string unitName);
        int GetUnitIdByName(string name);
        List<UnitsOfMeasurement> GetUnitsList();
    }
}