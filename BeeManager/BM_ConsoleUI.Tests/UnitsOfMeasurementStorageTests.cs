using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BM_ConsoleUI.Tests
{
    public class UnitsOfMeasurementStorageTests : IClassFixture<BeeManagerTestContext>
    {
        BeeManagerTestContext fixture;
        public UnitsOfMeasurementStorageTests(BeeManagerTestContext fixture)
        {
            if (this.fixture == null)
            {
                this.fixture = fixture;
            }
        }

        [Fact]
        public void AddUnit_WhenNewProductAdded_ThenItShouldBeAddedToStorage()
        {
            var mockUnitsStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockUnitsStorage.GetUnitsList().Count();

            var newProduct = "TestProd";
            mockUnitsStorage.AddUnit(newProduct);

            int lengthAfter = mockUnitsStorage.GetUnitsList().Count();

            Assert.True(lengthBefore + 1 == lengthAfter);
        }

        [Fact]
        public void AddUnit_WhenNewUnitAdded_ThenItShouldReturnCorrectName()
        {
            var mockUnitsStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);

            var newProduct = "TestProd";
            mockUnitsStorage.AddUnit(newProduct);

            int lastId = mockUnitsStorage.GetUnitsList().LastOrDefault().Id;

            string newName = mockUnitsStorage.GetUnitById(lastId).Unit;

            Assert.True(newName == newProduct, $"{newProduct} wasn't last added Product.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetUnitById_WhenMethodCalled_ThenItShouldReturnCorrectUnit(int id)
        {
            var mockUnitsStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);

            var newProd = mockUnitsStorage.GetUnitById(id);

            Assert.True(newProd.Id == id, $"Wrong Id");
        }

        [Fact]
        public void DeleteUnitnById_WhenUnitDeleted_ThenItShouldBeRemovedFromStorage()
        {
            var mockUnitsStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockUnitsStorage.GetUnitsList().Count();

            int lastId = mockUnitsStorage.GetUnitsList().LastOrDefault().Id;

            mockUnitsStorage.DeleteUnitById(lastId);

            int lengthAfter = mockUnitsStorage.GetUnitsList().Count();

            Assert.True(lengthBefore - 1 == lengthAfter);
        }
    }
}
