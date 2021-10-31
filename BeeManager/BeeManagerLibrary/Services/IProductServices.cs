using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Services
{
    public interface IProductServices
    {
        int GetProductIdByName(string name);
        string GetProductNameById(int id);
        List<Product> GetProductsList();
        void UpdateProduct(int id, string name);
    }
}