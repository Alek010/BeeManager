using BeeManagerLibrary.Repository;
using System;
using System.Linq;

namespace BeeManagerLibrary.Services
{
    public class ProductServices : IProductServices
    {
        IProductStorage _productStorage;
        public ProductServices(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public string GetProductNameById(int id)
        {
            var productList = _productStorage.GetProductsList();

            return productList.FirstOrDefault(p => p.Id == id).Name;
        }

        public int GetProductIdByName(string name)
        {
            var productList = _productStorage.GetProductsList();

            return productList.Find(p => p.Name == name).Id;
        }
    }
}
