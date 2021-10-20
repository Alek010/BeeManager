using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    class ProductionByYearView
    {
        public void RenderSummaryInConsole()
        {
            SetHeaderOfView();

            ProductionByYear productionByYear = new ProductionByYear();
            var productServices = new ProductServices();
            var unitsOfMeasurementService = new UnitsOfMeasurementServices();

            for (int i = 0; i < productionByYear.Summary.Count; i++)
            {
                if (productionByYear.Summary[i].ProductId == 2)
                {
                    Console.WriteLine($" {productionByYear.Summary[i].Year}\t" +
                                      $" {productServices.GetProductNameById(productionByYear.Summary[i].ProductId)}\t" +
                                      $" {productionByYear.Summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(productionByYear.Summary[i].UnitOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {productionByYear.Summary[i].Year}\t" +
                                      $"    {productServices.GetProductNameById(productionByYear.Summary[i].ProductId)}\t" +
                                      $" {productionByYear.Summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(productionByYear.Summary[i].UnitOfMeasurementId)}");
                }

            }
        }

        private void SetHeaderOfView()
        {
            Console.WriteLine($" Gads\t   Produkts    Skaits\tMērvienība");
        }
    }
}
