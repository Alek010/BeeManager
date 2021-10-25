using BM_ConsoleUI.Models;
using BM_ConsoleUI.Services;
using BM_ConsoleUI.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BM_ConsoleUI.Tests
{
    public class ProductionSummaryViewTest: IClassFixture<BeeManagerTestContext>
    {
        ProductionSummaryView productionSummary; 

        public ProductionSummaryViewTest(BeeManagerTestContext fixture)
        {
            var productServices = new ProductServices(new ProductStorage(fixture.BeeManagerTestDb));
            var productionStorage = new ProductionStorage(fixture.BeeManagerTestDb);
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);
            var unitsOfMeasurementServices = new UnitsOfMeasurementServices(unitsOfMeasurementStorage);
            var ProductionServices = new ProductionServices(productionStorage, productServices, unitsOfMeasurementServices);

            productionSummary = new ProductionSummaryView(productServices, ProductionServices, unitsOfMeasurementServices, productionStorage);           
        }


        [Fact]
        public void ApplyFilter_WhenNoParameters_ThenReturnUnfilteredSummary()
        {
            var expected = ProductionServiciesTest.ProductionSummary;

            productionSummary.ApplyFilter();

            var actual = productionSummary.ProductionSummaryFiltered;

            AssertEqualityOfProductionSummuryLists(expected, actual);
        }

        [Theory]
        [InlineData(2021)]
        public void ApplyFilter_WhenFileredByYear_ThenReturnFilteredSummary(int byYear)
        {
            var expected = ExpectedProductionSummaryFilteredbyYear2021;

            productionSummary.ApplyFilter(byYear);

            var actual = productionSummary.ProductionSummaryFiltered;

            AssertEqualityOfProductionSummuryLists(expected, actual);
        }

        [Theory]
        [InlineData("Medus")]
        public void ApplyFilter_WhenFileredByProductName_ThenReturnFiltered(string ProductName)
        {
            var expected = ExpectedProductionSummaryFilteredbyProductNameOfHoney;

            productionSummary.ApplyFilter(ProductName);

            var actual = productionSummary.ProductionSummaryFiltered;

            AssertEqualityOfProductionSummuryLists(expected, actual);
        }

        [Theory]
        [InlineData(2020, "Medus")]
        public void ApplyFilter_WhenFileredByYearAndProductName_ThenReturnFilteredSummary(int Year, string ProductName)
        {
            var expected = ExpectedProductionSummaryFilteredbyYear2020AndproductNameOfHoney;

            productionSummary.ApplyFilter(Year, ProductName);

            var actual = productionSummary.ProductionSummaryFiltered;

            AssertEqualityOfProductionSummuryLists(expected, actual);
        }

        private void AssertEqualityOfProductionSummuryLists(List<ProductionSummary> expected, List<ProductionSummary> actual)
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
