using BM_ConsoleUI.Services;
using BM_ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BM_ConsoleUI.Tests
{
    public class ProductionViewTest: IClassFixture<BeeManagerTestContext>
    {
        ProductionView productionView;

        public ProductionViewTest(BeeManagerTestContext fixture)
        {
            var productServices = new ProductServices(new ProductStorage(fixture.BeeManagerTestDb));
            var productionStorage = new ProductionStorage(fixture.BeeManagerTestDb);
            var unitsOfMeasurementStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);
            var unitsOfMeasurementServices = new UnitsOfMeasurementServices(unitsOfMeasurementStorage);
            var ProductionServices = new ProductionServices(productionStorage, productServices, unitsOfMeasurementServices);

            productionView = new ProductionView(productServices, productionStorage, unitsOfMeasurementServices, ProductionServices);
        }

        [Fact]
        public void ApplyFilter_WhenNoParameters_ThenReturnUnfilteredProductionList()
        {
            var expected = UnfilteredProductionList;

            productionView.ApplyFilter();
            var actual = productionView.Records;

            AssertEqualityOfProductionSummuryLists(expected, actual);
        }

        [Fact]
        public void ApplyFilter_WhenFilteredRecordsByYearof2021_ThenReturnFilteredList()
        {
            var expected = ProductionListFIlteredByYear2021;

            productionView.ApplyFilter(2021);
            var actual = productionView.Records;

            AssertEqualityOfProductionSummuryLists(expected, actual);
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

        private List<Production> ProductionListFIlteredByYear2021 = new List<Production>()
        {
                new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 },
                new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 }
        };
    }
}
