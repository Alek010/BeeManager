using BM_ConsoleUI.Models;
using System.Collections.Generic;

namespace BM_ConsoleUI
{
    public interface IProductionByYear
    {
        List<ProductionSummary> Summary { get; set; }
    }
}