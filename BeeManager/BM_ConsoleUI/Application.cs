using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class Application : IApplication
    {
        IProductionServices _productionServices;
        IProductServices _productServices;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;
        IProductionStorage _productionStorage;
        IProductStorage _productStorage;
        IUnitsOfMeasurementStorage _unitsOfMeasurementStorage;
        public Application(IProductionServices productionServices, IProductServices productServices, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionStorage productionStorage, IProductStorage productStorage, IUnitsOfMeasurementStorage unitsOfMeasurementStorage)
        {
            _productionServices = productionServices;
            _productServices = productServices;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;
            _productionStorage = productionStorage;
            _productStorage = productStorage;
            _unitsOfMeasurementStorage = unitsOfMeasurementStorage;
        }

        public void Run()
        {
            //_productionServices.GetProduction();
            //_productServices.GetProducts();
            var name = _unitsOfMeasurementServices.GetUnitNameById(2);
            Console.WriteLine(name);
        }
    }
}
