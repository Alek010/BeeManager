using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    class ProductionView
    {
        private List<Production> Records { get; set; }


        public ProductionView()
        {
            var productionStorage = new ProductionStorage();
            Records = productionStorage.GetProductionList();
        }

        public void RenderRecordsInConsole()
        {
            SetHeadersOfView();

            var productServices = new ProductServices();
            var unitsOfMeasurementService = new UnitsOfMeasurementServices();

            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].ProductId == 2)
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $" {productServices.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $"    {productServices.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {unitsOfMeasurementService.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }

            }
        }

        private void SetHeadersOfView()
        {
            Console.WriteLine($"    Datums\t   Produkts    Skaits\tMērvienība");
        }
    }
}
