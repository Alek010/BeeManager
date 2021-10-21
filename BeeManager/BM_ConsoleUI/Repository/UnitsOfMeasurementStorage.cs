using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class UnitsOfMeasurementStorage : IUnitsOfMeasurementStorage
    {
        private List<UnitsOfMeasurement> UnitsStorageList { get; set; }

        public UnitsOfMeasurementStorage()
        {
            UnitsStorageList = new List<UnitsOfMeasurement>();
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 1, Unit = "Litrs" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 2, Unit = "Gabals" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 3, Unit = "Kilograms" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 4, Unit = "Grams" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 5, Unit = "Iepakojums" });
        }

        public UnitsOfMeasurement GetUnitById(int id)
        {
            return UnitsStorageList.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProductById(int id)
        {
            var product = GetUnitById(id);
            UnitsStorageList.Remove(product);
        }

        public void AddUnit(string unitName)
        {
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = UnitsStorageList.LastOrDefault().Id + 1, Unit = unitName });
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            return UnitsStorageList;
        }
    }
}
