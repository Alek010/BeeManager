using System.Collections.Generic;

namespace BM_ConsoleUI.Services
{
    public interface IProductionServices
    {
        void GetProduction();
        List<Production> GetProductionList();
    }
}