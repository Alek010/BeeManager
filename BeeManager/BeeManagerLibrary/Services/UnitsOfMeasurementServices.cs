using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Services
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

        public int GetUnitIdByName(string name)
        {
            var productList = _unitsOfMeasurementStorage.GetUnitsList();

            return productList.Find(p => p.Unit == name).Id;
        }

        public void UpdateUnit(int id, string unitName)
        {
            _unitsOfMeasurementStorage.UpdateUnit(id, unitName);
        }

        public void AddUnit(string unitName)
        {
            _unitsOfMeasurementStorage.AddUnit(unitName);
        }

        public void DeleteUnitById(int id)
        {
            _unitsOfMeasurementStorage.DeleteUnitById(id);
        }

        public List<UnitsOfMeasurement> GetUnitsList()
        {
            return _unitsOfMeasurementStorage.GetUnitsList();
        }


    }
}
