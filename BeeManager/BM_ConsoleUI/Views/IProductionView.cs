using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public interface IProductionView
    {
        void RenderRecordsInConsole(List<Production> list);
    }
}