using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using System;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public class ProductionSummaryView : IProductionSummaryView
    {
        public List<ProductionSummary> ProductionSummaryFiltered { get; set; }
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;

        public ProductionSummaryView(IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
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
