using System;

namespace BM_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var newProd = new Production() {
                Date = new DateTime(2021, 10, 1), 
                ProductId = 2, 
                Quantity = 45.52, 
                UnitsOfMeasurementId = 2 };

            ProductionStorage.AddProduction(newProd);
            ProductionStorage.DeleteProductionById(2);
            ProductionStorage.GetProduction();

            ProductStorage.AddProduct("Test");
            ProductStorage.GetProducts();

            UnitsOfMeasurementStorage.AddUnit("Centimetrs");
            UnitsOfMeasurementStorage.GetUnits();

        }
    }
}
