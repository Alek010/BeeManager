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

                AssertEqualityOfProductionLists(expected, actual);
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

                AssertEqualityOfProductionLists(expected, actual);
            }
        }

        [Fact]
        public void GetFullProductionSummary_ReturnUnfilteredSummary()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = ProductionSummary;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFullProductionSummary();

                AssertEqualityOfProductionSummaryLists(expected, actual);
            }
        }

        [Theory]
        [InlineData(2021)]
        public void GetFilteredProductionSummary_WhenFileredByYear_ThenReturnFilteredSummary(int byYear)
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = ExpectedProductionSummaryFilteredbyYear2021;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFilteredProductionSummary(byYear);

                AssertEqualityOfProductionSummaryLists(expected, actual);
            }
        }

        [Theory]
        [InlineData("Medus")]
        public void GetFilteredProductionSummary_WhenFileredByProductName_ThenReturnFiltered(string ProductName)
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = ExpectedProductionSummaryFilteredbyProductNameOfHoney;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFilteredProductionSummary(ProductName);

                AssertEqualityOfProductionSummaryLists(expected, actual);
            }
        }

        [Theory]
        [InlineData(2020, "Medus")]
        public void GetFilteredProductionSummary_WhenFileredByYearAndProductName_ThenReturnFilteredSummary(int Year, string ProductName)
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = ExpectedProductionSummaryFilteredbyYear2020AndproductNameOfHoney;

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                var actual = mockProductionStorage.GetFilteredProductionSummary(Year, ProductName);

                AssertEqualityOfProductionSummaryLists(expected, actual);
            }
        }

        [Fact]
        public void UpdateProductById_WhenMethodCalled_ThenProductNameUpdated()
        {
            using (BeeManagerTestContext fixture = new BeeManagerTestContext())
            {
                var expected = new Production() { Id = 1, Date = new DateTime(2019, 9, 20), ProductId = 2, Quantity = 100.55, UnitsOfMeasurementId = 2 };

                var mockProductionStorage = new ProductionStorage(fixture.BeeManagerTestDb);

                mockProductionStorage.UpdateProductionById(1, new DateTime(2019, 9, 20), 2, 100.55, 2);

                var actual = mockProductionStorage.GetProductionById(1);

                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.ProductId, actual.ProductId);
                Assert.Equal(expected.Quantity, actual.Quantity);
                Assert.Equal(expected.UnitsOfMeasurementId, actual.UnitsOfMeasurementId);
            }

        }

        private void AssertEqualityOfProductionLists(List<Production> expected, List<Production> actual)
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

        private static List<ProductionSummary> ProductionSummary = new List<ProductionSummary>()
        {
            new ProductionSummary(){Year = 2019, ProductId = 1, Quantity = 21.5, UnitOfMeasurementId = 1 },
            new ProductionSummary(){Year = 2020, ProductId = 2, Quantity = 3, UnitOfMeasurementId = 2 },
            new ProductionSummary(){Year = 2020, ProductId = 3, Quantity = 1, UnitOfMeasurementId = 3 },
            new ProductionSummary(){Year = 2020, ProductId = 1, Quantity = 32, UnitOfMeasurementId = 1 },
            new ProductionSummary(){Year = 2021, ProductId = 1, Quantity = 104.7, UnitOfMeasurementId = 1 }
        };

        private void AssertEqualityOfProductionSummaryLists(List<ProductionSummary> expected, List<ProductionSummary> actual)
        {
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Year, actual[i].Year);
                Assert.Equal(expected[i].ProductId, actual[i].ProductId);
                Assert.Equal(expected[i].Quantity, actual[i].Quantity);
                Assert.Equal(expected[i].UnitOfMeasurementId, actual[i].UnitOfMeasurementId);
            }
        }

        private List<ProductionSummary> ExpectedProductionSummaryFilteredbyYear2021 = new List<ProductionSummary>()
        {
                new ProductionSummary(){Year = 2021, ProductId = 1, Quantity = 104.7, UnitOfMeasurementId = 1 }
        };

        private List<ProductionSummary> ExpectedProductionSummaryFilteredbyProductNameOfHoney = new List<ProductionSummary>()
        {
                new ProductionSummary(){Year = 2019, ProductId = 1, Quantity = 21.5, UnitOfMeasurementId = 1 },
                new ProductionSummary(){Year = 2020, ProductId = 1, Quantity = 32, UnitOfMeasurementId = 1 },
                new ProductionSummary(){Year = 2021, ProductId = 1, Quantity = 104.7, UnitOfMeasurementId = 1 }
        };

        private List<ProductionSummary> ExpectedProductionSummaryFilteredbyYear2020AndproductNameOfHoney = new List<ProductionSummary>()
        {
                new ProductionSummary(){Year = 2020, ProductId = 1, Quantity = 32, UnitOfMeasurementId = 1 },
        };
    }
}
