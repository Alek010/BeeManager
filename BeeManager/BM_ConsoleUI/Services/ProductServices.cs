using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI.Services
{
    public class ProductServices
    {
        public string GetProductNameById(int id)
        {
            var productStorage = new ProductStorage();
            var productList = productStorage.GetProductsList();

            return productList.FirstOrDefault(p => p.Id == id).Name;
        }

        public void GetProducts()
        {
            var productStorage = new ProductStorage();
            var productList = productStorage.GetProductsList();

            foreach (var item in productList)
            {
                Console.WriteLine(productList.IndexOf(item));
                Console.WriteLine(item.Name);
            }
        }
    }
}
