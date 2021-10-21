using System.Collections.Generic;

namespace BM_ConsoleUI
{
    public interface IProductionStorage
    {
        void AddProduction(Production production);
        void DeleteProductionById(int id);
        Production GetProductionById(int id);
        List<Production> GetProductionList();
    }
}