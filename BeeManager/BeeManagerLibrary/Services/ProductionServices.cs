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
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;

        public ProductionServices()
        {
        }

        public ProductionServices(IProductionStorage productionStorage, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productionStorage = productionStorage;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }

        public List<Production> GetProductionList()
        {
            return _productionStorage.GetFullProductionList(); ;
        }

        public List<ProductionSummary> ReturnSummaryList(List<Production> list)
        {
            return list.GroupBy(x => (x.Date.Year,
                                             x.ProductId,
                                             x.UnitsOfMeasurementId))
                        .Select(x => new ProductionSummary()
                                        {
                                            Year = x.Key.Year,
                                            ProductId = x.Key.ProductId,
                                            Quantity = x.Sum(x => x.Quantity),
                                            UnitOfMeasurementId = x.Key.UnitsOfMeasurementId
                                        })
                        .ToList();
        }
    }
}

