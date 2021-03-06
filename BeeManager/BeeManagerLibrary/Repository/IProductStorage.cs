using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Repository
{
    public interface IProductStorage
    {
        void AddProduct(string productName);
        void DeleteProductById(int id);
        Product GetProductById(int id);
        int GetProductIdByName(string name);
        List<Product> GetProductsList();
        void UpdateProduct(int id, string productName);
    }
}