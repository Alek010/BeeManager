using System;
using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class ProductionStorage
    {
        private List<Production> ProductionStorageList { get; set; }

        public ProductionStorage()
        {
            ProductionStorageList = new List<Production>();
            ProductionStorageList.Add(new Production() { Id = 1, Date = new DateTime(2019, 9, 30), ProductId = 1, Quantity = 21.5, UnitsOfMeasurementId = 1 });
            ProductionStorageList.Add(new Production() { Id = 2, Date = new DateTime(2020, 10, 16), ProductId = 2, Quantity = 3, UnitsOfMeasurementId = 2 });
            ProductionStorageList.Add(new Production() { Id = 3, Date = new DateTime(2020, 3, 20), ProductId = 3, Quantity = 1, UnitsOfMeasurementId = 3 });
            ProductionStorageList.Add(new Production() { Id = 4, Date = new DateTime(2020, 7, 4), ProductId = 1, Quantity = 32, UnitsOfMeasurementId = 1 });
            ProductionStorageList.Add(new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 });
            ProductionStorageList.Add(new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 });
        }

        public void AddProduction(Production production)
        {
            ProductionStorageList.Add(new Production() { 
                Id = ProductionStorageList.LastOrDefault().Id + 1,
                Date = production.Date,
                ProductId = production.ProductId,
                Quantity = production.Quantity,
                UnitsOfMeasurementId = production.UnitsOfMeasurementId
            });
        }

        public Production GetProductionById(int id)
        {
            return ProductionStorageList.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteProductionById(int id)
        {
            var product = GetProductionById(id);
            ProductionStorageList.Remove(product);
        }

        public void GetProduction()
        {

            var productStorage = new ProductStorage();
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage();

            foreach (var item in ProductionStorageList)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Date);
                Console.WriteLine(productStorage.GetProductNameById(item.ProductId));
                Console.WriteLine(item.Quantity);
                Console.WriteLine(unitsOfMeasurementStorage.GetUnitNameById(item.ProductId));
            }
        }

        public List<Production> GetProductionList()
        {
            return ProductionStorageList;
        }
    }
}
