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

        private readonly IProductionStorage _productionStorage;
        public HomeController(IProductionServices productionServices, IProductionStorage productionStorage)
        {
            _productionServices = productionServices;
            _productionStorage = productionStorage;
        }

        public IActionResult Index()
        {
            var productionList = _productionServices.GetAllProductionRecords();
            return View("Index", productionList);
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
