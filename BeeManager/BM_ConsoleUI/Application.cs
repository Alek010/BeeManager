using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using BM_ConsoleUI.Views;
using System;

namespace BM_ConsoleUI
{
    public class Application : IApplication
    {
        IProductionServices _productionServices;
        IProductionStorage _productionStorage;
        IProductionView _productionView;
        IProductionSummaryView _productionSummaryView;
        public Application(IProductionServices productionServices, IProductionStorage productionStorage, IProductionView productionView, IProductionSummaryView productionSummaryView)
        {
            _productionServices = productionServices;
            _productionStorage = productionStorage;
            _productionView = productionView;
            _productionSummaryView = productionSummaryView;
        }

        public void Run()
        {
            Console.WriteLine("Labdien!");

            Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            _productionView.RenderRecordsInConsole(_productionServices.GetAllProductionRecords());

            Console.WriteLine("\nIevadiet jaunu ierakstu par saražoto produkciju: Šūnu medus 45.52 kg 01.10.2021");

            var newProd = new Production()
            {
                Date = new DateTime(2021, 10, 1),
                ProductId = 2,
                Quantity = 45.52,
                UnitsOfMeasurementId = 2
            };
            Console.WriteLine("Jaunajā sarakstā jābūt 7 ierakstiem!\n");

            _productionStorage.AddProduction(newProd);

            _productionView.RenderRecordsInConsole(_productionServices.GetAllProductionRecords());


            Console.WriteLine("\nSaražotās produkcijas žūrnāls par 2021.gadu\n");

            _productionView.RenderRecordsInConsole(_productionServices.GetFilteredProductionRecords(2021));

            Console.WriteLine("\nProdukcijas žurnāla atskaite\n");

            _productionSummaryView.RenderSummaryInConsole(_productionServices.GetAllProductionSummaryRecords());

            int year = 2021;
            Console.WriteLine($"\nSaražotās produkcijas atskaite par {year}.\n");


            _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords(year));

            Console.WriteLine("\nSaražotās produkcijas žurnāla atskaite atlasīta pēc medus produkta.\n");

            _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords("Šūnu medus"));

            Console.WriteLine("\nSaražotās produkcijas žurnāla atskaite atlasīts pēc medus produkta 2020.gadā.\n");

            _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords(2020, "Medus"));
        }
    }
}
