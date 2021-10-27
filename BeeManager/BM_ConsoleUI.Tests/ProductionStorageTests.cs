using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Linq;
using Xunit;

namespace BeeManagerLibrary.Tests
{
    public class ProductionStorageTests : IClassFixture<BeeManagerTestContext>
    {
        BeeManagerTestContext fixture;
        public ProductionStorageTests(BeeManagerTestContext fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddProduction_WhenNewProductionAdded_ThenItShouldBeAddedToStorage()
        {
            var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockProductionStorage.GetProductionList().Count();

            var newProduct = new Production() 
            { 
                Date = new DateTime(2019, 9, 30), 
                ProductId = 3, 
                Quantity = 21.5, 
                UnitsOfMeasurementId = 1 
            };

            mockProductionStorage.AddProduction(newProduct);

            int lengthAfter = mockProductionStorage.GetProductionList().Count();

            Assert.True(lengthBefore + 1 == lengthAfter);
        }

        [Fact]
        public void AddProduction_WhenNewProductionAdded_ThenItShouldReturnCorrectQuantity()
        {
            var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

            var newProduction = new Production()
            {
                Date = new DateTime(2019, 9, 30),
                ProductId = 3,
                Quantity = 21.5,
                UnitsOfMeasurementId = 1
            };

            mockProductionStorage.AddProduction(newProduction);

            int lastId = mockProductionStorage.GetProductionList().LastOrDefault().Id;

            double newQuantity = mockProductionStorage.GetProductionById(lastId).Quantity;

            Assert.True(newQuantity == newProduction.Quantity, $"{newProduction} wasn't last added Product.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetProductionById_WhenMethodCalled_ThenItShouldReturnCorrectProduction(int id)
        {
            var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

            var newProd = mockProductionStorage.GetProductionById(id);

            Assert.True(newProd.Id == id, $"Wrong Id");
        }

        [Fact]
        public void DeleteProductionById_WhenProductionDeleted_ThenItShouldBeRemovedFromStorage()
        {
            var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockProductionStorage.GetProductionList().Count();

            int lastId = mockProductionStorage.GetProductionList().LastOrDefault().Id;

            mockProductionStorage.DeleteProductionById(lastId);

            int lengthAfter = mockProductionStorage.GetProductionList().Count();

            Assert.True(lengthBefore - 1 == lengthAfter);
        }
    }
}
