using BM_ConsoleUI.Models;
using BM_ConsoleUI.Services;
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

        /// <summary>
        /// If empty returns unfiltered records.
        /// </summary>
        public void ApplyFilter()
        {
            ProductionSummaryFiltered = _productionServices.ReturnSummaryList(_productionStorage.GetProductionList());
        }
        public void ApplyFilter(int byYear)
        {
            ProductionSummaryFiltered = _productionServices.ReturnSummaryList(_productionStorage.GetProductionList())
                                        .Where(w => w.Year == byYear)
                                        .ToList();
        }
        public void ApplyFilter(string byProduct)
        {
            ProductionSummaryFiltered = _productionServices.ReturnSummaryList(_productionStorage.GetProductionList())
                                        .Where(w => w.ProductId == _productServices.GetProductIdByName(byProduct))
                                        .ToList();
        }
        public void ApplyFilter(int byYear, string byProduct)
        {
            ProductionSummaryFiltered = _productionServices.ReturnSummaryList(_productionStorage.GetProductionList())
                                        .Where(w => w.Year == byYear)
                                        .Where(w => w.ProductId == _productServices.GetProductIdByName(byProduct))
                                        .ToList();
        }

        public void RenderSummaryInConsole()
        {
            SetHeaderOfView();

            var summary = ProductionSummaryFiltered;

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
