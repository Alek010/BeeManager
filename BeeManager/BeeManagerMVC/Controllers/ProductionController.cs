using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using BeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Edit(int Id)
        {
            var prod = _productionServices.GetProductionById(Id);
            var prodModel = new ProductionModel
            {
                Id = prod.Id,
                Date = prod.Date.ToShortDateString(),
                Product = _productServices.GetProductNameById(prod.ProductId),
                Quantity = prod.Quantity,
                Units = _unitsOfMeasurementServices.GetUnitNameById(prod.UnitsOfMeasurementId)

            };

            ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Name", "Name");
            ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Unit", "Unit");

            return View(prodModel);
        }

        [HttpPost]
        public IActionResult Edit([Bind(include: "Id, Date, Product, Quantity, Units")]ProductionModel model)
        {
            _productionServices.UpdateProductionById(
                model.Id,
                DateTime.Parse(model.Date),
                _productServices.GetProductIdByName(model.Product),
                model.Quantity,
                _unitsOfMeasurementServices.GetUnitIdByName(model.Units)
                );
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Name", "Name");
            ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Unit", "Unit");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind(include: "Id, Date, Product, Quantity, Units")] ProductionModel model)
        {
            var prodModel = new Production
            {
                Date = DateTime.Parse(model.Date),
                ProductId = _productServices.GetProductIdByName(model.Product),
                Quantity = model.Quantity,
                UnitsOfMeasurementId = _unitsOfMeasurementServices.GetUnitIdByName(model.Units)
            };

            _productionServices.AddProduction(prodModel);

            return RedirectToAction("Index");
        }
    }
}
