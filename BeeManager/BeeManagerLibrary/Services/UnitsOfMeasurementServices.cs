using BeeManagerLibrary.Exceptions;
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

            if (unitsOfMeasurementList.Find(f => f.Id == id) == null)
            {
                throw new MeasurementUnitNotFoundException($"Measurement unit with ID number: {id} not found");
            }

            return unitsOfMeasurementList.FirstOrDefault(p => p.Id == id).Unit;
        }

        public int GetUnitIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MeasurementUnitNameIsNullOrWhiteSpaceException($"Entered string of measurement unit is null, empty or white space");
            }

            var unitsOfMeasurementList = _unitsOfMeasurementStorage.GetUnitsList();

            if (unitsOfMeasurementList.Find(f => f.Unit == name) == null)
            {
                throw new MeasurementUnitNotFoundException($"Measurement unit with name: {name} not found");
            }

            return unitsOfMeasurementList.Find(p => p.Unit == name).Id;
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
