using System.Collections.Generic;

namespace BM_ConsoleUI
{
    public interface IProductStorage
    {
        void AddProduct(string productName);
        void DeleteProductById(int id);
        Product GetProductById(int id);
        List<Product> GetProductsList();
    }
}