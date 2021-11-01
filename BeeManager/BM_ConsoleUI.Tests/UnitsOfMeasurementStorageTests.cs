﻿using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System.Linq;
using Xunit;

namespace BeeManagerLibrary.Tests
{
    public class UnitsOfMeasurementStorageTests : IClassFixture<BeeManagerTestContext>
    {
        BeeManagerTestContext fixture;
        public UnitsOfMeasurementStorageTests(BeeManagerTestContext fixture)
        {
            this.fixture = fixture;
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

        [Fact]
        public void UpdateProductById_WhenMethodCalled_ThenProductNameUpdated()
        {
            var expected = new UnitsOfMeasurement() { Id = 1, Unit = "UpdatedUnit" };

            var mockUnitStorage = new UnitsOfMeasurementStorage(fixture.BeeManagerTestDb);

            mockUnitStorage.UpdateUnit(1, "UpdatedUnit");

            var actual = mockUnitStorage.GetUnitById(1);

            Assert.Equal(expected.Unit, actual.Unit);
        }
    }
}
