using System.Collections.Generic;

namespace BeeManagerLibrary.Views
{
    public interface IProductionView
    {
        void ApplyFilter();
        void ApplyFilter(int Year);
        void RenderRecordsInConsole();
    }
}