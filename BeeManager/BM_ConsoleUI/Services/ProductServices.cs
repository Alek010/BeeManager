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

        public int GetProductIdByName(string name)
        {
            var productStorage = new ProductStorage();
            var productList = productStorage.GetProductsList();

            return productList.Find(p => p.Name == name).Id;
        }



    }
}
