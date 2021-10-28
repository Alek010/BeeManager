using BeeManagerLibrary.Services;
using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Views
{
    public class ProductionView /*: IProductionView*/
    {
        public List<Production> Records { get; set; }
        IProductServices _productServices;
        IProductionStorage _productionStorage;
        IUnitsOfMeasurementServices _unitsOfMeasurementServices;


        public ProductionView(IProductServices productServices, IProductionStorage productionStorage, IUnitsOfMeasurementServices unitsOfMeasurementServices, IProductionServices productionServices)
        {
            _productServices = productServices;
            _productionStorage = productionStorage;
            _unitsOfMeasurementServices = unitsOfMeasurementServices;

            Records = new List<Production>();
        }


        public void ApplyFilter()
        {
            throw new NotImplementedException();
        }

        public void ApplyFilter(int Year)
        {
            throw new NotImplementedException();
        }

        public void RenderRecordsInConsole()
        {
            throw new NotImplementedException();
        }
    }
}
