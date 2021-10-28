using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BeeManagerLibrary.Tests
{
    public class ProductionStorageTests : IClassFixture<BeeManagerTestContext>
    {
        //BeeManagerTestContext fixture;
        public ProductionStorageTests(/*BeeManagerTestContext fixture*/)
        {
            //this.fixture = fixture;
        }

        [Fact]
        public void AddProduction_WhenNewProductionAdded_ThenItShouldBeAddedToStorage()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                int lengthBefore = mockProductionStorage.GetFullProductionList().Count();

                var newProduct = new Production()
                {
                    Date = new DateTime(2019, 9, 30),
                    ProductId = 3,
                    Quantity = 21.5,
                    UnitsOfMeasurementId = 1
                };

                mockProductionStorage.AddProduction(newProduct);

                int lengthAfter = mockProductionStorage.GetFullProductionList().Count();

                Assert.True(lengthBefore + 1 == lengthAfter);

            }
        }

        [Fact]
        public void AddProduction_WhenNewProductionAdded_ThenItShouldReturnCorrectQuantity()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
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

                int lastId = mockProductionStorage.GetFullProductionList().LastOrDefault().Id;

                double newQuantity = mockProductionStorage.GetProductionById(lastId).Quantity;

                Assert.True(newQuantity == newProduction.Quantity, $"{newProduction} wasn't last added Product.");
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetProductionById_WhenMethodCalled_ThenItShouldReturnCorrectProduction(int id)
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var newProd = mockProductionStorage.GetProductionById(id);

                Assert.True(newProd.Id == id, $"Wrong Id");
            }

        }

        [Fact]
        public void DeleteProductionById_WhenProductionDeleted_ThenItShouldBeRemovedFromStorage()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                int lengthBefore = mockProductionStorage.GetFullProductionList().Count();

                int lastId = mockProductionStorage.GetFullProductionList().LastOrDefault().Id;

                mockProductionStorage.DeleteProductionById(lastId);

                int lengthAfter = mockProductionStorage.GetFullProductionList().Count();

                Assert.True(lengthBefore - 1 == lengthAfter);
            }
        }

        [Fact]
        public void GetFullProductionList_ReturnUnfilteredList()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = UnfilteredProductionList;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFullProductionList();

                AssertEqualityOfProductionSummuryLists(expected, actual);
            }
        }

        [Fact]
        public void GetFilteredProductionList_WhenFilteredByYear2021_ThenReturnFilteredList()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = ProductionListFIlteredByYear2021;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFilteredProductionList(2021);

                AssertEqualityOfProductionSummuryLists(expected, actual);
            }
        }

        private void AssertEqualityOfProductionSummuryLists(List<Production> expected, List<Production> actual)
        {
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Date, actual[i].Date);
                Assert.Equal(expected[i].ProductId, actual[i].ProductId);
                Assert.Equal(expected[i].Quantity, actual[i].Quantity);
                Assert.Equal(expected[i].UnitsOfMeasurementId, actual[i].UnitsOfMeasurementId);
            }
        }

        private List<Production> UnfilteredProductionList = new List<Production>()
        {
            new Production() { Id = 1, Date = new DateTime(2019, 9, 30), ProductId = 1, Quantity = 21.5, UnitsOfMeasurementId = 1 },
            new Production() { Id = 2, Date = new DateTime(2020, 10, 16), ProductId = 2, Quantity = 3, UnitsOfMeasurementId = 2 },
            new Production() { Id = 3, Date = new DateTime(2020, 3, 20), ProductId = 3, Quantity = 1, UnitsOfMeasurementId = 3 },
            new Production() { Id = 4, Date = new DateTime(2020, 7, 4), ProductId = 1, Quantity = 32, UnitsOfMeasurementId = 1 },
            new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 },
            new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 }
        };

        private readonly List<Production> ProductionListFIlteredByYear2021 = new List<Production>()
        {
            new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 },
            new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 }
        };
    }
}
