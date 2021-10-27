using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Repository
{
    public interface IProductionStorage
    {
        void AddProduction(Production production);
        void DeleteProductionById(int id);
        Production GetProductionById(int id);
        List<Production> GetProductionList();
    }
}