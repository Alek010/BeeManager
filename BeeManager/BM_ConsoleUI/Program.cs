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

            ProductionStorage.AddProduction(newProd);
            ProductionStorage.DeleteProductionById(2);
            ProductionStorage.GetProduction();

            ProductStorage.AddProduct("Test");
            ProductStorage.GetProducts();

            UnitsOfMeasurementStorage.AddUnit("Centimetrs");
            UnitsOfMeasurementStorage.GetUnits();

            Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            ProductionView productionView = new ProductionView();
            productionView.RenderRecordsInConsole();

            Console.WriteLine("\nPārskats par saražoto produkciju pēc gada un produkcijas veida.\n");

            ProductionByYearView productionByYearView = new ProductionByYearView();
            productionByYearView.RenderSummaryInConsole();



        }
    }
}
