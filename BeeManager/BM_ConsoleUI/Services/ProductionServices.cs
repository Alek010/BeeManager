using System;
using System.Collections.Generic;

namespace BM_ConsoleUI.Services
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
            return  _productionStorage.GetProductionList(); ;
        }
    }
}
