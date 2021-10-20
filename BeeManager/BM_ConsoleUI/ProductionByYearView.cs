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
            var productStorage = new ProductStorage();
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage();

            for (int i = 0; i < productionByYear.Summary.Count; i++)
            {
                if (productionByYear.Summary[i].ProductId == 2)
                {
                    Console.WriteLine($" {productionByYear.Summary[i].Year}\t" +
                                      $" {productStorage.GetProductNameById(productionByYear.Summary[i].ProductId)}\t" +
                                      $" {productionByYear.Summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementStorage.GetUnitNameById(productionByYear.Summary[i].UnitOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {productionByYear.Summary[i].Year}\t" +
                                      $"    {productStorage.GetProductNameById(productionByYear.Summary[i].ProductId)}\t" +
                                      $" {productionByYear.Summary[i].Quantity}\t" +
                                      $" {unitsOfMeasurementStorage.GetUnitNameById(productionByYear.Summary[i].UnitOfMeasurementId)}");
                }

            }
        }

        private void SetHeaderOfView()
        {
            Console.WriteLine($" Gads\t   Produkts    Skaits\tMērvienība");
        }
    }
}
