using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
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

        public Production GetProductionById(int id)
        {
            return _beeManagerContext.Production.SingleOrDefault(p => p.Id == id);
        }
        public void DeleteProductionById(int id)
        {
            var product = GetProductionById(id);
            _beeManagerContext.Production.Remove(product);

            _beeManagerContext.SaveChanges();
        }

        public List<Production> GetProductionList()
        {
            return _beeManagerContext.Production.ToList();
        }
    }
}
