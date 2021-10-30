using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using System;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public class ProductionView: IProductionView
    {
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;


        public ProductionView(IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }

        public void RenderRecordsInConsole(List<Production> productionList)
        {
            SetHeadersOfView();

            var records = productionList;

            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].ProductId == 2)
                {
                    Console.WriteLine($" {records[i].Date.ToShortDateString()}\t" +
                                      $" {_productServices.GetProductNameById(records[i].ProductId)}\t" +
                                      $" {records[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(records[i].UnitsOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {records[i].Date.ToShortDateString()}\t" +
                                      $"    {_productServices.GetProductNameById(records[i].ProductId)}\t" +
                                      $" {records[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(records[i].UnitsOfMeasurementId)}");
                }
            }
        }

        private void SetHeadersOfView()
        {
            Console.WriteLine($"    Datums\t   Produkts    Skaits\tMērvienība");
        }

    }
}
