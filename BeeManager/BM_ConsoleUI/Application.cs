using BeeManagerLibrary.Models;
using BeeManagerLibrary.Exceptions;
using BeeManagerLibrary.Services;
using BM_ConsoleUI.Views;
using System;

namespace BM_ConsoleUI
{
    public class Application : IApplication
    {
        IProductionServices _productionServices;
        IProductionView _productionView;
        IProductionSummaryView _productionSummaryView;
        IProductServices _productServices;
        public Application(IProductionServices productionServices, IProductionView productionView, IProductionSummaryView productionSummaryView, IProductServices productServices)
        {
            _productionServices = productionServices;
            _productionView = productionView;
            _productionSummaryView = productionSummaryView;
            _productServices = productServices;
        }

        public void Run()
        {
           var list = _productServices.GetProductsList();

            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Id}   Product Name: {item.Name}           CreatedDate: {item.CreatedDate}     UpdatedDate: {item.UpdatedDate}");
            }

            int Id;
            string newProductName;

            Console.WriteLine($"\nEdit product name by choosing it's ID and writing poduct name to update.\n");
            Console.Write($"Type ID of product to be updated: ");
            Id = int.Parse(Console.ReadLine());
            Console.Write($"Type new product name to be updated: ");
            newProductName = Console.ReadLine();


            try
            {
                _productServices.GetProductNameById(Id);
            }
            catch (ProductNotFoundException message)
            {
                Console.WriteLine(message);
            }


            _productServices.UpdateProduct(Id, newProductName);

            Console.WriteLine("\nTable records of products after update.");

            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Id}   Product Name: {item.Name}           CreatedDate: {item.CreatedDate}     UpdatedDate: {item.UpdatedDate}");
            }



            //    Console.WriteLine("Labdien!");

            //    Console.WriteLine("\nSaražotās produkcijas žūrnāls.\n");

            //    _productionView.RenderRecordsInConsole(_productionServices.GetAllProductionRecords());

            //    Console.WriteLine("\nIevadiet jaunu ierakstu par saražoto produkciju: Šūnu medus 45.52 kg 01.10.2021");

            //    var newProd = new Production()
            //    {
            //        Date = new DateTime(2021, 10, 1),
            //        ProductId = 2,
            //        Quantity = 45.52,
            //        UnitsOfMeasurementId = 2
            //    };
            //    Console.WriteLine("Jaunajā sarakstā jābūt 7 ierakstiem!\n");

            //    _productionServices.AddProduction(newProd);

            //    _productionView.RenderRecordsInConsole(_productionServices.GetAllProductionRecords());


            //    Console.WriteLine("\nSaražotās produkcijas žūrnāls par 2021.gadu\n");

            //    _productionView.RenderRecordsInConsole(_productionServices.GetFilteredProductionRecords(2021));

            //    Console.WriteLine("\nProdukcijas žurnāla atskaite\n");

            //    _productionSummaryView.RenderSummaryInConsole(_productionServices.GetAllProductionSummaryRecords());

            //    int year = 2021;
            //    Console.WriteLine($"\nSaražotās produkcijas atskaite par {year}.\n");


            //    _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords(year));

            //    Console.WriteLine("\nSaražotās produkcijas žurnāla atskaite atlasīta pēc medus produkta.\n");

            //    _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords("Šūnu medus"));

            //    Console.WriteLine("\nSaražotās produkcijas žurnāla atskaite atlasīts pēc medus produkta 2020.gadā.\n");

            //    _productionSummaryView.RenderSummaryInConsole(_productionServices.GetFilteredProductionSummaryRecords(2020, "Medus"));
        }
    }
}
