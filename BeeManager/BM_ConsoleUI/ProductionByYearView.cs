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
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        IProductionByYear _productionByYear;
        public ProductionByYearView(IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionByYear productionByYear)
        {
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
            _productionByYear = productionByYear;
        }
        public void RenderSummaryInConsole()
        {
            SetHeaderOfView();

            for (int i = 0; i < _productionByYear.Summary.Count; i++)
            {
                if (_productionByYear.Summary[i].ProductId == 2)
                {
                    Console.WriteLine($" {_productionByYear.Summary[i].Year}\t" +
                                      $" {_productServices.GetProductNameById(_productionByYear.Summary[i].ProductId)}\t" +
                                      $" {_productionByYear.Summary[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(_productionByYear.Summary[i].UnitOfMeasurementId)}");
                }
                else
                {
                    Console.WriteLine($" {_productionByYear.Summary[i].Year}\t" +
                                      $"    {_productServices.GetProductNameById(_productionByYear.Summary[i].ProductId)}\t" +
                                      $" {_productionByYear.Summary[i].Quantity}\t" +
                                      $" {_unitsOfMeasurementServices.GetUnitNameById(_productionByYear.Summary[i].UnitOfMeasurementId)}");
                }

            }
        }

        private void SetHeaderOfView()
        {
            Console.WriteLine($" Gads\t   Produkts    Skaits\tMērvienība");
        }
    }
}
