using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class ProductionStorage
    {

        private static List<Production> ProductionStorageList { get; set; }

        static ProductionStorage()
        {
            ProductionStorageList = new List<Production>();
            ProductionStorageList.Add(new Production() { Id = 1, Date = new DateTime(2019, 9, 30), ProductId = 1, Quantity = 21.5, UnitsOfMeasurementId = 1 });
            ProductionStorageList.Add(new Production() { Id = 2, Date = new DateTime(2020, 10, 16), ProductId = 2, Quantity = 3, UnitsOfMeasurementId = 2 });
            ProductionStorageList.Add(new Production() { Id = 3, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 });
            ProductionStorageList.Add(new Production() { Id = 4, Date = new DateTime(2021, 8, 1), ProductId = 2, Quantity = 4.4, UnitsOfMeasurementId = 2 });

        }

        public static void AddProduction(Production production)
        {
            ProductionStorageList.Add(new Production() { 
                Id = ProductionStorageList.LastOrDefault().Id + 1,
                Date = production.Date,
                ProductId = production.ProductId,
                Quantity = production.Quantity,
                UnitsOfMeasurementId = production.UnitsOfMeasurementId
            });
        }

        public static Production GetProductionById(int id)
        {
            return ProductionStorageList.FirstOrDefault(p => p.Id == id);
        }

        public static void DeleteProductionById(int id)
        {
            var product = GetProductionById(id);
            ProductionStorageList.Remove(product);
        }

        public static void GetProduction()
        {
            foreach (var item in ProductionStorageList)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Date);
                Console.WriteLine(ProductStorage.GetProductNameById(item.ProductId));
                Console.WriteLine(item.Quantity);
                Console.WriteLine(UnitsOfMeasurementStorage.GetUnitNameById(item.ProductId));
            }
        }

        public static List<Production> GetProductionList()
        {
            return ProductionStorageList;
        }
    }
}
