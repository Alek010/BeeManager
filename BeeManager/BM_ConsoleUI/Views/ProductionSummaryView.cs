using BM_ConsoleUI.Models;
using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI.Views
{
    class ProductionSummaryView
    {
        public List<ProductionSummary> ProductionSummary { get; set; }
        public ProductionSummaryView()
        {
            var productionServices = new ProductionServices();

            ProductionSummary = productionServices.ReturnSummaryList();
        }

        /// <summary>
        /// If empty returns unfiltered records.
        /// </summary>
        public void FilterProduction()
        {
            RenderSummaryInConsole(ProductionSummary);
        }
        public void FilterProduction(int byYear)
        {
            var result  = ProductionSummary.Where(w => w.Year == byYear).ToList();

            RenderSummaryInConsole(result);
        }
        public void FilterProduction(string byProduct)
        {
            ProductServices product = new ProductServices();         

            var result = ProductionSummary.Where(w => w.ProductId == product.GetProductIdByName(byProduct)).ToList();

            RenderSummaryInConsole(result);
        }
        public void FilterProduction(int byYear, string byProduct)
        {
            ProductServices product = new ProductServices();

            var result = ProductionSummary.Where(w => w.Year == byYear)
                                        .Where(w => w.ProductId == product.GetProductIdByName(byProduct))
                                        .ToList();

            RenderSummaryInConsole(result);
        }


        private void RenderSummaryInConsole(List<ProductionSummary> summary)
        {
            SetHeaderOfView();

            var productServices = new ProductServices();

            var unitsOfMeasurementService = new UnitsOfMeasurementServices();

            for (int i = 0; i < summary.Count; i++)
            {
                if (summary[i].ProductId == 2)
                {
                    Console.WriteLine($" {summary[i].Year}\t" +
                                      $" {productServices.GetProductNameById(summary[i].ProductId)}\t" +
                                      $" {summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(summary[i].UnitOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {summary[i].Year}\t" +
                                      $"    {productServices.GetProductNameById(summary[i].ProductId)}\t" +
                                      $" {summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(summary[i].UnitOfMeasurementId)}");
                }

            }
        }

        private void SetHeaderOfView()
        {
            Console.WriteLine($" Gads\t   Produkts    Skaits\tMērvienība");
        }


    }
}
