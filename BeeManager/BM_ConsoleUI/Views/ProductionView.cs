using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI.Views
{
    public class ProductionView : IProductionView
    {
        private List<Production> Records { get; set; }
        IProductServices _productServices;
        IProductionStorage _productionStorage;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;


        public ProductionView(IProductServices productServices, IProductionStorage productionStorage, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionServices productionServices)
        {
            _productServices = productServices;
            _productionStorage = productionStorage;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;

            Records = new List<Production>();
        }

        /// <summary>
        /// If empty returns unfiltered records.
        /// </summary>
        public void ApplyFilter()
        {
            Records = _productionStorage.GetProductionList();
        }

        public void ApplyFilter(int Year)
        {
            Records = _productionStorage.GetProductionList()
                      .Where(w => w.Date.Year == Year)
                      .ToList();
        }

        public void RenderRecordsInConsole()
        {
            SetHeadersOfView();

            var records = Records;

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
