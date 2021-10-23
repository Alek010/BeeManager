using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public class ProductionView : IProductionView
    {
        private List<Production> Records { get; set; }
        IProductServices _productServices;
        IProductionStorage _productionStorage;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;

        public ProductionView(IProductServices productServices, IProductionStorage productionStorage, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productServices = productServices;
            _productionStorage = productionStorage;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }

        public void RenderRecordsInConsole(List<Production> list)
        {
            SetHeadersOfView();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ProductId == 2)
                {
                    Console.WriteLine($" {list[i].Date.ToShortDateString()}\t" +
                                      $" {_productServices.GetProductNameById(list[i].ProductId)}\t" +
                                      $" {list[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(list[i].UnitsOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {list[i].Date.ToShortDateString()}\t" +
                                      $"    {_productServices.GetProductNameById(list[i].ProductId)}\t" +
                                      $" {list[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(list[i].UnitsOfMeasurementId)}");
                }
            }
        }

        private void SetHeadersOfView()
        {
            Console.WriteLine($"    Datums\t   Produkts    Skaits\tMērvienība");
        }
    }
}
