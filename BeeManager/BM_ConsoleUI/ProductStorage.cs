using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class ProductStorage
    {

        public static List<Product> _productStorage { get; set; }

        static ProductStorage()
        {
            _productStorage = new List<Product>();
            _productStorage.Add(new Product() { Id = 1, Name = "Medus" });
            _productStorage.Add(new Product() { Id = 2, Name = "Šūnu medus" });
            _productStorage.Add(new Product() { Id = 3, Name = "Vasks" });
        }

        public static Product GetProductById(int id)
        {
            return _productStorage.FirstOrDefault(p => p.Id == id);
        }

        public static string GetProductNameById(int id)
        {
            return _productStorage.FirstOrDefault(p => p.Id == id).Name;
        }

        public static void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            _productStorage.Remove(product);
        }

        public static void AddProduct(string productName)
        {
            _productStorage.Add(new Product() { Id = _productStorage.LastOrDefault().Id + 1, Name = productName });
        }

        public static void GetProducts()
        {
            foreach (var item in _productStorage)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
        }
    }
}
