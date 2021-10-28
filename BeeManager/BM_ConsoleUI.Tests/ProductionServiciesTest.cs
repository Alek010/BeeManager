using BeeManagerLibrary.Models;
using BeeManagerLibrary.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BeeManagerLibrary.Tests
{
    public class ProductionServiciesTest
    {

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void ReturnSummaryList_WhenMethodCalled_ThenCorrectSummuryReturned(List<Production> productions)
        {
            //Arrange

            var expected = ProductionSummary;

            //Act
            ProductionServices productionServices = new ProductionServices();

            var actual = productionServices.ReturnSummaryList(productions);


            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Year, actual[i].Year);
                Assert.Equal(expected[i].ProductId, actual[i].ProductId);
                Assert.Equal(expected[i].Quantity, actual[i].Quantity);
                Assert.Equal(expected[i].UnitOfMeasurementId, actual[i].UnitOfMeasurementId);
            }
        }


        public static List<ProductionSummary> ProductionSummary = new List<ProductionSummary>()
            {
                new ProductionSummary(){Year = 2019, ProductId = 1, Quantity = 21.5, UnitOfMeasurementId = 1 },
                new ProductionSummary(){Year = 2020, ProductId = 2, Quantity = 3, UnitOfMeasurementId = 2 },
                new ProductionSummary(){Year = 2020, ProductId = 3, Quantity = 1, UnitOfMeasurementId = 3 },
                new ProductionSummary(){Year = 2020, ProductId = 1, Quantity = 32, UnitOfMeasurementId = 1 },
                new ProductionSummary(){Year = 2021, ProductId = 1, Quantity = 104.7, UnitOfMeasurementId = 1 }
            };


        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<Production> _data = new List<Production>
            {
                new Production() { Id = 1, Date = new DateTime(2019, 9, 30), ProductId = 1, Quantity = 21.5, UnitsOfMeasurementId = 1 },
                new Production() { Id = 2, Date = new DateTime(2020, 10, 16), ProductId = 2, Quantity = 3, UnitsOfMeasurementId = 2 },
                new Production() { Id = 3, Date = new DateTime(2020, 3, 20), ProductId = 3, Quantity = 1, UnitsOfMeasurementId = 3 },
                new Production() { Id = 4, Date = new DateTime(2020, 7, 4), ProductId = 1, Quantity = 32, UnitsOfMeasurementId = 1 },
                new Production() { Id = 5, Date = new DateTime(2021, 4, 18), ProductId = 1, Quantity = 18.7, UnitsOfMeasurementId = 1 },
                new Production() { Id = 6, Date = new DateTime(2021, 9, 2), ProductId = 1, Quantity = 86, UnitsOfMeasurementId = 1 }
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { _data };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }


    }
}
