using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Services
{
    public interface IProductionServices
    {
        List<Production> GetFilteredProductionRecords(int year);
        List<Production> GetAllProductionRecords();
        List<ProductionSummary> GetAllProductionSummaryRecords();
        List<ProductionSummary> GetFilteredProductionSummaryRecords(int year);
        List<ProductionSummary> GetFilteredProductionSummaryRecords(string productName);
        List<ProductionSummary> GetFilteredProductionSummaryRecords(int year, string productName);
        void AddProduction(Production production);
    }
}