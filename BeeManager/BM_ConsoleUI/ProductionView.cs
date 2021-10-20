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
        IProductServices _productServices;
        IProductionStorage _productionStorage;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        private List<Production> Records { get; set; }


        public ProductionView(IProductionStorage productionStorage, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productionStorage = productionStorage;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
            Records = _productionStorage.GetProductionList();
        }

        public void RenderRecordsInConsole()
        {
            SetHeadersOfView();

            for (int i = 0; i < Records.Count; i++)
            {
                if (Records[i].ProductId == 2)
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $" {_productServices.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {Records[i].Date.ToShortDateString()}\t" +
                                      $"    {_productServices.GetProductNameById(Records[i].ProductId)}\t" +
                                      $" {Records[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(Records[i].UnitsOfMeasurementId)}");
                }

            }
        }

        private void SetHeadersOfView()
        {
            Console.WriteLine($"    Datums\t   Produkts    Skaits\tMērvienība");
        }
    }
}
