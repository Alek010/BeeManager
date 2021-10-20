using System;

namespace BM_ConsoleUI.Services
{
    public class ProductionServices
    {
        public void GetProduction()
        {
            var unitsOfMeasurementService = new UnitsOfMeasurementServices();
            var productionStorage = new ProductionStorage();
            var productServices = new ProductServices();
            var productionList = productionStorage.GetProductionList();

            foreach (var item in productionList)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Date);
                Console.WriteLine(productServices.GetProductNameById(item.ProductId));
                Console.WriteLine(item.Quantity);
                Console.WriteLine(unitsOfMeasurementService.GetUnitNameById(item.ProductId));
            }
        }
    }
}
