using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using BeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

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
                                                         Product = x.Products.Name,
                                                         Quantity = x.Quantity,
                                                         Units = x.Units.Unit

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
                Product = prod.Products.Name,
                Quantity = prod.Quantity,
                Units = prod.Units.Unit

            };

            ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Id", "Name");
            ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Id", "Unit");

            return View(prodModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductionModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Id", "Name");
                ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Id", "Unit");
                return View(model);
            }

            _productionServices.UpdateProductionById(
                model.Id,
                (DateTime)model.Date,
                int.Parse(model.Product),
                (double)model.Quantity,
                int.Parse(model.Units)
                );

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Id", "Name");
            ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Id", "Unit");
            var model = new ProductionModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductionModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Product = new SelectList(_productServices.GetProductsList(), "Id", "Name");
                ViewBag.UnitsOfMeasurement = new SelectList(_unitsOfMeasurementServices.GetUnitsList(), "Id", "Unit");
                return View(model);
            }

            var prodModel = new Production
            {
                Date = (DateTime)model.Date,
                ProductId = int.Parse(model.Product),
                Quantity = (double)model.Quantity,
                UnitsOfMeasurementId = int.Parse(model.Units)
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
