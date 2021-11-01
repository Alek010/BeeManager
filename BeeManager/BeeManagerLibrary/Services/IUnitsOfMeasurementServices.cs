namespace BeeManagerLibrary.Services
{
    public interface IUnitsOfMeasurementServices
    {
        void AddUnit(string unitName);
        string GetUnitNameById(int id);
        void UpdateUnit(int id, string unitName);
    }
}