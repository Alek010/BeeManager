using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Services
{
    public class ProductionServices : IProductionServices
    {
        IProductionStorage _productionStorage;

        public ProductionServices(IProductionStorage productionStorage)
        {
            _productionStorage = productionStorage;
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

        public void AddProduction(Production production)
        {
            _productionStorage.AddProduction(production);
        }

        public void DeleteProductionById(int id)
        {
            _productionStorage.DeleteProductionById(id);
        }

        public void UpdateProductionById(int id, DateTime date, int productId, double quantity, int unitsOfMeasurementId)
        {
            _productionStorage.UpdateProductionById(id, date, productId, quantity, unitsOfMeasurementId);
        }

        public Production GetProductionById(int id)
        {
            return _productionStorage.GetProductionById(id);
        }
    }
}

