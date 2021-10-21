using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class ProductionStorage : IProductionStorage
    {
        public void AddProduction(Production production)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                context.Add(new Production()
                {
                    Date = production.Date,
                    ProductId = production.ProductId,
                    Quantity = production.Quantity,
                    UnitsOfMeasurementId = production.UnitsOfMeasurementId
                });
                context.SaveChanges();
            }
        }

        public Production GetProductionById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.Production.SingleOrDefault(p => p.Id == id);
            }
        }
        public void DeleteProductionById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                var product = GetProductionById(id);
                context.Production.Remove(product);

                context.SaveChanges();
            }
        }

        public List<Production> GetProductionList()
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.Production.ToList();
            }
        }
    }
}
