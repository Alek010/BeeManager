using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class UnitsOfMeasurementStorage
    {
        public static List<UnitsOfMeasurement> _unitsStorage { get; set; }

        static UnitsOfMeasurementStorage()
        {
            _unitsStorage = new List<UnitsOfMeasurement>();
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = 1, Unit = "Litrs" });
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = 2, Unit = "Gabals" });
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = 3, Unit = "Kilograms" });
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = 4, Unit = "Grams" });
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = 5, Unit = "Iepakojums" });
        }

        public static UnitsOfMeasurement GetUnitById(int id)
        {
            return _unitsStorage.FirstOrDefault(p => p.Id == id);
        }

        public static string GetUnitNameById(int id)
        {
            return _unitsStorage.FirstOrDefault(p => p.Id == id).Unit;
        }

        public static void DeleteProductById(int id)
        {
            var product = GetUnitById(id);
            _unitsStorage.Remove(product);
        }

        public static void AddUnit(string unitName)
        {
            _unitsStorage.Add(new UnitsOfMeasurement() { Id = _unitsStorage.LastOrDefault().Id + 1, Unit = unitName });
        }

        public static void GetProducts()
        {
            foreach (var item in _unitsStorage)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Unit);
            }
        }
    }
}
