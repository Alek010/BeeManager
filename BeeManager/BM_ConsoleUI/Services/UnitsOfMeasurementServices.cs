using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI.Services
{
    public class UnitsOfMeasurementServices
    {
        public string GetUnitNameById(int id)
        {
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage();
            var unitsOfMeasurementList = unitsOfMeasurementStorage.GetUnitsList();

            return unitsOfMeasurementList.FirstOrDefault(p => p.Id == id).Unit;
        }

        public void GetUnits()
        {
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage();
            var unitsOfMeasurementList = unitsOfMeasurementStorage.GetUnitsList();

            foreach (var item in unitsOfMeasurementList)
            {
                Console.WriteLine(unitsOfMeasurementList.IndexOf(item));
                Console.WriteLine(item.Unit);
            }
        }
    }
}
