﻿using BeeManagerLibrary.Repository;
using System;
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
    }
}