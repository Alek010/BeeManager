using BM_ConsoleUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class ProductionByYear
    {
        public List<ProductionSummary> Summary { get; set; }
        private List<Production> ProductionRecords { get; set; }

        public ProductionByYear()
        {
            Summary = new List<ProductionSummary>();

            ProductionRecords = ProductionStorage.GetProductionList();

            CalculateSummary();
        }

        private void CalculateSummary()
        {

            var result = ProductionRecords.GroupBy(x => (x.Date.Year, 
                                                         x.ProductId, 
                                                         x.UnitsOfMeasurementId))
                                          .Select(g => (g.Key.Year, 
                                                        g.Key.ProductId, 
                                                        Total: g.Sum(x => x.Quantity), 
                                                        g.Key.UnitsOfMeasurementId));

            foreach (var item in result)
            {
                ProductionSummary productionSummary = new ProductionSummary();

                productionSummary.Year = item.Year;
                productionSummary.ProductId = item.ProductId;
                productionSummary.Quantity = item.Total;
                productionSummary.UnitOfMeasurementId = item.UnitsOfMeasurementId;

                Summary.Add(productionSummary);
            }
        }
    }
}
