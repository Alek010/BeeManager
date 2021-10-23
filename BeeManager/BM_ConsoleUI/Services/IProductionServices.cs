using BM_ConsoleUI.Models;
using System.Collections.Generic;

namespace BM_ConsoleUI.Services
{
    public interface IProductionServices
    {
        void GetProduction();
        List<Production> GetProductionList();
        List<ProductionSummary> ReturnSummaryList(List<Production> list);
    }
}