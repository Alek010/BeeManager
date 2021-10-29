using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI.Views
{
    public class ProductionSummaryView : IProductionSummaryView
    {
        public List<ProductionSummary> ProductionSummaryFiltered { get; set; }
        IProductServices _productServices;
        IProductionServices _productionServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        IProductionStorage _productionStorage;

        public ProductionSummaryView(IProductServices productServices, IProductionServices productionServices, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionStorage productionStorage)
        {
            _productServices = productServices;
            _productionServices = productionServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
            _productionStorage = productionStorage;
        }



        public void RenderSummaryInConsole(List<ProductionSummary> productionSummaryList)
        {
            SetHeaderOfView();

            var summary = productionSummaryList;

            for (int i = 0; i < summary.Count; i++)
            {
                if (summary[i].ProductId == 2)
                {
                    Console.WriteLine($" {summary[i].Year}\t" +
                                      $" {_productServices.GetProductNameById(summary[i].ProductId)}\t" +
                                      $" {summary[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(summary[i].UnitOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {summary[i].Year}\t" +
                                      $"    {_productServices.GetProductNameById(summary[i].ProductId)}\t" +
                                      $" {summary[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(summary[i].UnitOfMeasurementId)}");
                }
            }
        }

        private void SetHeaderOfView()
        {
            Console.WriteLine($" Gads\t   Produkts    Skaits\tMērvienība");
        }
    }
}
