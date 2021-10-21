using BM_ConsoleUI.Models;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public interface IProductionSummaryView
    {
        List<ProductionSummary> ProductionSummary { get; set; }

        void FilterProduction();
        void FilterProduction(int byYear);
        void FilterProduction(int byYear, string byProduct);
        void FilterProduction(string byProduct);
    }
}