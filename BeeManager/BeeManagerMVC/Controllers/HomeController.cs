using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using BeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var productionSummary = _productionServices.GetAllProductionSummaryRecords();

            var list = new List<ProductionSummaryModel>();
            foreach (var item in productionSummary)
            {
                list.Add(new ProductionSummaryModel
                {
                    Year = item.Year,
                    ProductName = _productServices.GetProductNameById(item.ProductId),
                    Quantity = item.Quantity,
                    Unit = _unitsOfMeasurementServices.GetUnitNameById(item.UnitOfMeasurementId)
                });
            }
            return View(list);
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
