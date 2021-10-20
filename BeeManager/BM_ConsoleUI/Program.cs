using BM_ConsoleUI.Services;
using BM_ConsoleUI.Views;
using System;
using System.Text;

namespace BM_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Labdien!");

            Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            ProductionView productionView = new ProductionView();

            productionView.RenderRecordsInConsole();


            Console.WriteLine("\nIevadiet jaunu ierakstu par saražoto produkciju.");

            var newProd = new Production()
            {
                Date = new DateTime(2021, 10, 1),
                ProductId = 2,
                Quantity = 45.52,
                UnitsOfMeasurementId = 2
            };
            Console.WriteLine("Jaunajā sarakstā jābūt 7 ierakstiem (NESTRĀDĀ!!!)");

            var newProductionStorage = new ProductionStorage();
            newProductionStorage.AddProduction(newProd);

            productionView.RenderRecordsInConsole();


            Console.WriteLine("\nSaražotās produkcijas žūrnāls par 2020.\n");

            ProductionSummaryView productionSummaryView = new ProductionSummaryView();
            productionSummaryView.FilterProduction(2020);

            Console.WriteLine("\nSaražotās produkcijas žūrnāls atlasīts pēc medus produkta.\n");
            productionSummaryView.FilterProduction("Medus");






        }
    }
}
