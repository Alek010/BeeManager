using BeeManagerLibrary.Exceptions;
using BeeManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Repository
{
    public class ProductionStorage : IProductionStorage
    {
        private BeeManagerContext _beeManagerContext;
        public ProductionStorage()
        {
            _beeManagerContext = new BeeManagerContext(BeeManagerContext.GetDbContextOptions());
        }

        public ProductionStorage(BeeManagerContext beeManagerContext)
        {
            _beeManagerContext = beeManagerContext;
        }

        public void AddProduction(Production production)
        {
            _beeManagerContext.Add(new Production()
            {
                Date = production.Date,
                ProductId = production.ProductId,
                Quantity = production.Quantity,
                UnitsOfMeasurementId = production.UnitsOfMeasurementId
            });

            _beeManagerContext.SaveChanges();
        }

        public Production GetProductionRecordById(int id)
        {
            var productionRecord = _beeManagerContext.Production.SingleOrDefault(p => p.Id == id);

            if (productionRecord == null)
            {
                throw new ProductionRecordNotFoundException($"Production record with ID number: {id} not found");
            }

            return productionRecord;
        }
        public void DeleteProductionById(int id)
        {
            var productionRecord = GetProductionRecordById(id);

            if (productionRecord == null)
            {
                throw new ProductionRecordNotFoundException($"Production record with ID number: {id} not found");
            }

            _beeManagerContext.Production.Remove(productionRecord);

            _beeManagerContext.SaveChanges();
        }

        public void UpdateProductionRecordById(int id, DateTime date, int productId, double quantity, int unitsOfMeasurementId)
        {
            var productionRecord = GetProductionRecordById(id);

            if (productionRecord == null)
            {
                throw new ProductionRecordNotFoundException($"Production record with ID number: {id} not found");
            }

            productionRecord.Date = date;
            productionRecord.ProductId = productId;
            productionRecord.Quantity = quantity;
            productionRecord.UnitsOfMeasurementId = unitsOfMeasurementId;

            _beeManagerContext.Update(productionRecord);

            _beeManagerContext.SaveChanges();
        }

        public List<Production> GetFullProductionList()
        {
            return _beeManagerContext.Production.ToList();
        }

        /// <summary>
        /// Production List filtered by year.
        /// </summary>
        public List<Production> GetFilteredProductionList(int Year)
        {
            return _beeManagerContext.Production.Where(w => w.Date.Year == Year)
                                                .ToList();
        }


        public List<ProductionSummary> GetFullProductionSummary()
        {

            return _beeManagerContext.Production.ToList()
                                                .GroupBy(x => (x.Date.Year,
                                                               x.ProductId,
                                                               x.UnitsOfMeasurementId))
                                                .Select(x => new ProductionSummary()
                                                {
                                                    Year = x.Key.Year,
                                                    ProductId = x.Key.ProductId,
                                                    Quantity = x.Sum(x => x.Quantity),
                                                    UnitOfMeasurementId = x.Key.UnitsOfMeasurementId
                                                })
                                                .ToList();
        }

        public List<ProductionSummary> GetFilteredProductionSummary(int year)
        {

            return _beeManagerContext.Production.Where(w => w.Date.Year == year)
                                                .ToList()
                                                .GroupBy(x => (x.Date.Year,
                                                               x.ProductId,
                                                               x.UnitsOfMeasurementId))
                                                .Select(x => new ProductionSummary()
                                                {
                                                    Year = x.Key.Year,
                                                    ProductId = x.Key.ProductId,
                                                    Quantity = x.Sum(x => x.Quantity),
                                                    UnitOfMeasurementId = x.Key.UnitsOfMeasurementId
                                                })
                                                .ToList();
        }

        public List<ProductionSummary> GetFilteredProductionSummary(string productName)
        {
            int productId = _beeManagerContext.Products.ToList().Find(p => p.Name == productName).Id;

            return _beeManagerContext.Production.Where(w => w.ProductId == productId)
                                                .ToList()
                                                .GroupBy(x => (x.Date.Year,
                                                               x.ProductId,
                                                               x.UnitsOfMeasurementId))
                                                .Select(x => new ProductionSummary()
                                                {
                                                    Year = x.Key.Year,
                                                    ProductId = x.Key.ProductId,
                                                    Quantity = x.Sum(x => x.Quantity),
                                                    UnitOfMeasurementId = x.Key.UnitsOfMeasurementId
                                                })
                                                .ToList();
        }

        public List<ProductionSummary> GetFilteredProductionSummary(int year, string productName)
        {
            int productId = _beeManagerContext.Products.ToList().Find(p => p.Name == productName).Id;

            return _beeManagerContext.Production.Where(w => w.Date.Year == year)
                                                .Where(w => w.ProductId == productId)
                                                .ToList()
                                                .GroupBy(x => (x.Date.Year,
                                                               x.ProductId,
                                                               x.UnitsOfMeasurementId))
                                                .Select(x => new ProductionSummary()
                                                {
                                                    Year = x.Key.Year,
                                                    ProductId = x.Key.ProductId,
                                                    Quantity = x.Sum(x => x.Quantity),
                                                    UnitOfMeasurementId = x.Key.UnitsOfMeasurementId
                                                })
                                                .ToList();
        }

    }
}
