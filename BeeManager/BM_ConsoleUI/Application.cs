using BM_ConsoleUI.Services;
using BM_ConsoleUI.Views;
using System;

namespace BM_ConsoleUI
{
    public class Application : IApplication
    {
        IProductionServices _productionServices;
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        IProductionStorage _productionStorage;
        IProductStorage _productStorage;
        IUnitsOfMeasurementStorage _unitsOfMeasurementStorage;
        IProductionView _productionView;
        IProductionSummaryView _productionSummaryView;
        public Application(IProductionServices productionServices, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionStorage productionStorage, IProductStorage productStorage, IUnitsOfMeasurementStorage unitsOfMeasurementStorage, IProductionView productionView, IProductionSummaryView productionSummaryView)
        {
            _productionServices = productionServices;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
            _productionStorage = productionStorage;
            _productStorage = productStorage;
            _unitsOfMeasurementStorage = unitsOfMeasurementStorage;
            _productionView = productionView;
            _productionSummaryView = productionSummaryView;
        }

        public void Run()
        {
            Console.WriteLine("Labdien!");

            Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            _productionView.RenderRecordsInConsole(_productionStorage.GetProductionList());

            Console.WriteLine("\nIevadiet jaunu ierakstu par saražoto produkciju.");

            var newProd = new Production()
            {
                Date = new DateTime(2021, 10, 1),
                ProductId = 2,
                Quantity = 45.52,
                UnitsOfMeasurementId = 2
            };
            Console.WriteLine("Jaunajā sarakstā jābūt 7 ierakstiem (NESTRĀDĀ!!!)");

            _productionStorage.AddProduction(newProd);

            _productionSummaryView.ApplyFilter();
            _productionSummaryView.RenderSummaryInConsole();

            int year = 2021;
            Console.WriteLine($"\nSaražotās produkcijas žūrnāls par {year}.\n");

            _productionSummaryView.ApplyFilter(year);
            _productionSummaryView.RenderSummaryInConsole();

            Console.WriteLine("\nSaražotās produkcijas žūrnāls atlasīts pēc medus produkta.\n");
            _productionSummaryView.ApplyFilter("Šūnu medus");
            _productionSummaryView.RenderSummaryInConsole();

            Console.WriteLine("\nSaražotās produkcijas žūrnāls atlasīts pēc medus produkta 2020.gadā.\n");
            _productionSummaryView.ApplyFilter(2020, "Medus");
            _productionSummaryView.RenderSummaryInConsole();
        }
    }
}
