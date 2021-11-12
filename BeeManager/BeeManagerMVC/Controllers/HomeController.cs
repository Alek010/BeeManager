using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using BeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeeManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductionServices _productionServices;
        private readonly IProductServices _productServices;
        private readonly IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        public HomeController(IProductionServices productionServices, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productionServices = productionServices;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }

        public IActionResult Index(string productName, string year)
        {
            var productionSummary = _productionServices.GetAllProductionSummaryRecords();

            if (!string.IsNullOrEmpty(productName))
            {
                productionSummary = _productionServices.GetFilteredProductionSummaryRecords(productName);
            }

            if (!string.IsNullOrEmpty(year))
            {
                productionSummary = _productionServices.GetFilteredProductionSummaryRecords(int.Parse(year));
            }

            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(year))
            {
                productionSummary = _productionServices.GetFilteredProductionSummaryRecords(int.Parse(year), productName);
            }
         

            var productionSummaryViewModel = new ProductionSummaryViewModel()
            {
                Products = new SelectList(_productServices.GetProductsList().Select(s => s.Name)),

                Years = new SelectList(_productionServices.GetAllProductionSummaryRecords().OrderBy(o => o.Year)
                                                                                           .Select(s => s.Year)
                                                                                           .Distinct()
                                                                                           .ToList()),

                ProductionSummary = productionSummary.Select(x => new ProductionSummaryModel()
                                                        {
                                                            Year = x.Year,
                                                            ProductName = _productServices.GetProductNameById(x.ProductId),
                                                            Quantity = x.Quantity,
                                                            Unit = _unitsOfMeasurementServices.GetUnitNameById(x.UnitOfMeasurementId)
                                                        })
                                                     .ToList()

            };

            return View(productionSummaryViewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
