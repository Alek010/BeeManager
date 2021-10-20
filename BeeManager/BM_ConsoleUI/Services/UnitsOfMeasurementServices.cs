using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI.Services
{
    public class UnitsOfMeasurementServices : IUnitsOfMeasurementServices
    {
        IUnitsOfMeasurementStorage _unitsOfMeasurementStorage;
        public UnitsOfMeasurementServices(IUnitsOfMeasurementStorage unitsOfMeasurementStorage)
        {
            _unitsOfMeasurementStorage = unitsOfMeasurementStorage;
        }
        public string GetUnitNameById(int id)
        {
            var unitsOfMeasurementList = _unitsOfMeasurementStorage.GetUnitsList();

            return unitsOfMeasurementList.FirstOrDefault(p => p.Id == id).Unit;
        }

        public void GetUnits()
        {
            var unitsOfMeasurementList = _unitsOfMeasurementStorage.GetUnitsList();

            foreach (var item in unitsOfMeasurementList)
            {
                Console.WriteLine(unitsOfMeasurementList.IndexOf(item));
                Console.WriteLine(item.Unit);
            }
        }
    }
}
