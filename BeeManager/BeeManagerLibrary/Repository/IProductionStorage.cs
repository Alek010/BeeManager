using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Repository
{
    public interface IProductionStorage
    {
        void AddProduction(Production production);
        void DeleteProductionById(int id);
        Production GetProductionById(int id);
        List<Production> GetFullProductionList();
        List<Production> GetFilteredProductionList(int Year);
        List<ProductionSummary> GetFilteredProductionSummary(int year, string productName);
        List<ProductionSummary> GetFilteredProductionSummary(string productName);
        List<ProductionSummary> GetFilteredProductionSummary(int year);
        List<ProductionSummary> GetFullProductionSummary();
    }
}