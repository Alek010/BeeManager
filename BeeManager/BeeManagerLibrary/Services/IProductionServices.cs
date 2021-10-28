using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Services
{
    public interface IProductionServices
    {
        List<Production> GetProductionList();
        List<ProductionSummary> ReturnSummaryList(List<Production> list);
    }
}