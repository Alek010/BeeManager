using System.Collections.Generic;

namespace BM_ConsoleUI
{
    public interface IUnitsOfMeasurementStorage
    {
        void AddUnit(string unitName);
        void DeleteProductById(int id);
        UnitsOfMeasurement GetUnitById(int id);
        List<UnitsOfMeasurement> GetUnitsList();
    }
}