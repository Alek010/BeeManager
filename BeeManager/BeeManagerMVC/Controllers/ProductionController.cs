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
        public IActionResult Index(string year)
        {
            var productionList = _productionServices.GetAllProductionRecords();

            if (!string.IsNullOrEmpty(year))
            {
                productionList = _productionServices.GetFilteredProductionRecords(int.Parse(year));
            }

            var productionViewModel = new ProductionViewModel()
            {
                Years = new SelectList(_productionServices.GetAllProductionRecords().GroupBy(g => g.Date.Year)
                                                                                    .Select(s => s.Key.ToString())
                                                                                    .ToList()),

                Production = productionList.Select(x => new ProductionModel()
                                                        {
                                                         Id = x.Id,
                                                         Date = x.Date,
                                                         Product = _productServices.GetProductNameById(x.ProductId),
                                                         Quantity = x.Quantity,
                                                         Units = _unitsOfMeasurementServices.GetUnitNameById(x.UnitsOfMeasurementId)

                })
                                            .ToList()
            };

            return View(productionViewModel);
        }

        public IActionResult Edit(int Id)
        {
            var prod = _productionServices.GetProductionById(Id);
            var prodModel = new ProductionModel
            {
                Id = prod.Id,
                Date = prod.Date,
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
                model.Date,
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
                Date = model.Date,
                ProductId = _productServices.GetProductIdByName(model.Product),
                Quantity = model.Quantity,
                UnitsOfMeasurementId = _unitsOfMeasurementServices.GetUnitIdByName(model.Units)
            };

            _productionServices.AddProduction(prodModel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete (int id)
        {
            _productionServices.DeleteProductionById(id);
            return RedirectToAction("Index");
        }
    }
}
