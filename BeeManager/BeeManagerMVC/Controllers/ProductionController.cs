using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using BeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeManagerMVC.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionServices _productionServices;
        private readonly IProductServices _productServices;
        private readonly IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        public ProductionController(IProductionServices productionServices, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices)
        {
            _productionServices = productionServices;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
        }
        public IActionResult Index()
        {
            var productionList = _productionServices.GetAllProductionRecords();
            var list = new List<ProductionModel>();
            foreach (var item in productionList)
            {
                list.Add(new ProductionModel 
                { 
                    Id = item.Id,
                    Date = item.Date.ToShortDateString(),
                    Product = _productServices.GetProductNameById(item.ProductId),
                    Quantity = item.Quantity,
                    Units = _unitsOfMeasurementServices.GetUnitNameById(item.UnitsOfMeasurementId)
                });
            }
            return View(list);
        }
    }
}
