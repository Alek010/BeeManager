using System.Collections.Generic;

namespace BM_ConsoleUI.Views
{
    public interface IProductionView
    {
        void ApplyFilter();
        void ApplyFilter(int Year);
        void RenderRecordsInConsole();
    }
}