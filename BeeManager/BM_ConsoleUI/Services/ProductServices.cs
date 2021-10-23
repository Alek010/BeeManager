using System;
using System.Linq;

namespace BM_ConsoleUI.Services
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

        public void GetProducts()
        {
            var productList = _productStorage.GetProductsList();

            foreach (var item in productList)
            {
                Console.WriteLine(productList.IndexOf(item));
                Console.WriteLine(item.Name);
            }
        }

        public int GetProductIdByName(string name)
        {
            var productList = _productStorage.GetProductsList();

            return productList.Find(p => p.Name == name).Id;
        }
    }
}
