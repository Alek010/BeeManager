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
            Records = ProductionStorage.GetProductionList();
        }

        public void RenderRecordsInConsole()
        {
            SetHeadersOfView();

            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].ProductId == 2)
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $" {ProductStorage.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {UnitsOfMeasurementStorage.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $"    {ProductStorage.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {UnitsOfMeasurementStorage.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }

            }
        }

        private void SetHeadersOfView()
        {
            Console.WriteLine($"    Datums\t   Produkts    Skaits\tMērvienība");
        }
    }
}
