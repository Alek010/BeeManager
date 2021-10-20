using BM_ConsoleUI.Services;
using System;
using System.Text;

namespace BM_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var newProd = new Production()
            {
                Date = new DateTime(2021, 10, 1),
                ProductId = 2,
                Quantity = 45.52,
                UnitsOfMeasurementId = 2
            };

            var newProductionStorage = new ProductionStorage();
            var newProductionServices = new ProductionServices();
            var newProductServices = new ProductServices();

            newProductionStorage.AddProduction(newProd);
            newProductionStorage.DeleteProductionById(2);
            newProductionServices.GetProduction();

            var newProductStorage = new ProductStorage();

            newProductStorage.AddProduct("Test");
            newProductServices.GetProducts();

            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage();
            var unitsOfMeasurementServices = new UnitsOfMeasurementServices();

            unitsOfMeasurementStorage.AddUnit("Centimetrs");
            unitsOfMeasurementServices.GetUnits();

            Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            ProductionView productionView = new ProductionView();
            productionView.RenderRecordsInConsole();

            Console.WriteLine("\nPārskats par saražoto produkciju pēc gada un produkcijas veida.\n");

            ProductionByYearView productionByYearView = new ProductionByYearView();
            productionByYearView.RenderSummaryInConsole();



        }
    }
}
