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

        public void GetProduction()
        {
            var productionList = _productionStorage.GetProductionList();

            foreach (var item in productionList)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Date);
                Console.WriteLine(_productServices.GetProductNameById(item.ProductId));
                Console.WriteLine(item.Quantity);
                Console.WriteLine(_unitsOfMeasurementServices.GetUnitNameById(item.ProductId));
            }
        }

        public List<Production> GetProductionList()
        {
            return _productionStorage.GetProductionList(); ;
        }

        public List<ProductionSummary> ReturnSummaryList(List<Production> list)
        {
            var summary = new List<ProductionSummary>();
            var result = list.GroupBy(x => (x.Date.Year,
                                                    x.ProductId,
                                                    x.UnitsOfMeasurementId))
                                        .Select(g => (g.Key.Year,
                                                    g.Key.ProductId,
                                                    Total: g.Sum(x => x.Quantity),
                                                    g.Key.UnitsOfMeasurementId));

            foreach (var item in result)
            {
                ProductionSummary productionSummary = new ProductionSummary();

                productionSummary.Year = item.Year;
                productionSummary.ProductId = item.ProductId;
                productionSummary.Quantity = item.Total;
                productionSummary.UnitOfMeasurementId = item.UnitsOfMeasurementId;

                summary.Add(productionSummary);
            }

            return summary;
        }
    }
}

