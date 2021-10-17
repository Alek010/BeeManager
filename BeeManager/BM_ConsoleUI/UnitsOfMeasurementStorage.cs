using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class UnitsOfMeasurementStorage
    {
        private static List<UnitsOfMeasurement> UnitsStorageList { get; set; }

        static UnitsOfMeasurementStorage()
        {
            UnitsStorageList = new List<UnitsOfMeasurement>();
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 1, Unit = "Litrs" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 2, Unit = "Gabals" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 3, Unit = "Kilograms" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 4, Unit = "Grams" });
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = 5, Unit = "Iepakojums" });
        }

        public static UnitsOfMeasurement GetUnitById(int id)
        {
            return UnitsStorageList.FirstOrDefault(p => p.Id == id);
        }

        public static string GetUnitNameById(int id)
        {
            return UnitsStorageList.FirstOrDefault(p => p.Id == id).Unit;
        }

        public static void DeleteProductById(int id)
        {
            var product = GetUnitById(id);
            UnitsStorageList.Remove(product);
        }

        public static void AddUnit(string unitName)
        {
            UnitsStorageList.Add(new UnitsOfMeasurement() { Id = UnitsStorageList.LastOrDefault().Id + 1, Unit = unitName });
        }

        public static void GetUnits()
        {
            foreach (var item in UnitsStorageList)
            {
                Console.WriteLine(UnitsStorageList.IndexOf(item));
                Console.WriteLine(item.Unit);
            }
        }

        public static List<UnitsOfMeasurement> GetUnitsList()
        {
            return UnitsStorageList;
        }
    }
}
