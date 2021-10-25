using BM_ConsoleUI.Models;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public interface IProductionSummaryView
    {
        List<ProductionSummary> ProductionSummaryFiltered { get; set; }
        void ApplyFilter();
        void ApplyFilter(int byYear);
        void ApplyFilter(int byYear, string byProduct);
        void ApplyFilter(string byProduct);
        public void RenderSummaryInConsole();
    }
}