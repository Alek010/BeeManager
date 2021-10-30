﻿using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Services
{
    public class ProductionServices : IProductionServices
    {
        IProductionStorage _productionStorage;
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;

        public ProductionServices(IProductionStorage productionStorage, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productionStorage = productionStorage;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }

        public List<Production> GetAllProductionRecords()
        {
            return _productionStorage.GetFullProductionList();
        }

        public List<Production> GetFilteredProductionRecords(int year)
        {
            return _productionStorage.GetFilteredProductionList(year);
        }

        public List<ProductionSummary> GetAllProductionSummaryRecords()
        {
            return _productionStorage.GetFullProductionSummary();
        }

        public List<ProductionSummary> GetFilteredProductionSummaryRecords(int year)
        {
            return _productionStorage.GetFilteredProductionSummary(year);
        }

        public List<ProductionSummary> GetFilteredProductionSummaryRecords(string productName)
        {
            return _productionStorage.GetFilteredProductionSummary(productName);
        }

        public List<ProductionSummary> GetFilteredProductionSummaryRecords(int year, string productName)
        {
            return _productionStorage.GetFilteredProductionSummary(year, productName);
        }
    }
}

