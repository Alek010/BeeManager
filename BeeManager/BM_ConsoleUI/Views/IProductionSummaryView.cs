using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public interface IProductionSummaryView
    {
        public void RenderSummaryInConsole(List<ProductionSummary> productionSummaryList);
    }
}