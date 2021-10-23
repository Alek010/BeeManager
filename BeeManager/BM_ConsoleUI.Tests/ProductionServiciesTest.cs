using BM_ConsoleUI.Models;
using BM_ConsoleUI.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BM_ConsoleUI.Tests
{
    public class ProductionServiciesTest
    {

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void ReturnSummaryList_WhenMethodCalled_ThenCorrectSummuryReturned(List<Production> productions)
        {
            //Arrange

            List<ProductionSummary> expected = new List<ProductionSummary>()
            {
                new ProductionSummary(){Year = 2021, ProductId = 1, Quantity = 104.7, UnitOfMeasurementId = 1 }
            };

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


        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<Production> _data = new List<Production>
            {
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
