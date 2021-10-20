using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class ProductStorage
    {

        private List<Product> ProductStorageList { get; set; }

        public ProductStorage()
        {
            ProductStorageList = new List<Product>();
            ProductStorageList.Add(new Product() { Id = 1, Name = "Medus" });
            ProductStorageList.Add(new Product() { Id = 2, Name = "Šūnu medus" });
            ProductStorageList.Add(new Product() { Id = 3, Name = "Vasks" });
            ProductStorageList.Add(new Product() { Id = 4, Name = "Ziedputekšņi" });
        }

        public Product GetProductById(int id)
        {
            return ProductStorageList.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            ProductStorageList.Remove(product);
        }

        public void AddProduct(string productName)
        {
            ProductStorageList.Add(new Product() { Id = ProductStorageList.LastOrDefault().Id + 1, Name = productName });
        }

        public List<Product> GetProductsList()
        {
            return ProductStorageList;
        }
    }
}
