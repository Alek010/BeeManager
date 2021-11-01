﻿using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System.Linq;
using Xunit;

namespace BeeManagerLibrary.Tests
{
    public class ProductStorageTests : IClassFixture<BeeManagerTestContext>
    {
        BeeManagerTestContext fixture;
        public ProductStorageTests(BeeManagerTestContext fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddProduct_WhenNewProductAdded_ThenItShouldBeAddedToStorage()
        {
            var mockProductStorage = new ProductStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockProductStorage.GetProductsList().Count();

            var newProduct = "TestProd";
            mockProductStorage.AddProduct(newProduct);

            int lengthAfter = mockProductStorage.GetProductsList().Count();

            Assert.True(lengthBefore + 1 == lengthAfter);
        }

        [Fact]
        public void AddProduct_WhenNewProductAdded_ThenItShouldReturnCorrectName()
        {
            var mockProductStorage = new ProductStorage(fixture.BeeManagerTestDb);

            var newProduct = "TestProd";
            mockProductStorage.AddProduct(newProduct);

            int lastId = mockProductStorage.GetProductsList().LastOrDefault().Id;

            string newName = mockProductStorage.GetProductById(lastId).Name;

            Assert.True(newName == newProduct, $"{newProduct} wasn't last added Product.");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetProductById_WhenMethodCalled_ThenItShouldReturnCorrectProduct(int id)
        {
            var mockProductStorage = new ProductStorage(fixture.BeeManagerTestDb);

            var newProd = mockProductStorage.GetProductById(id);

            Assert.True(newProd.Id == id, $"Wrong Id");
        }

        [Fact]
        public void DeleteUnitnById_WhenUnitDeleted_ThenItShouldBeRemovedFromStorage()
        {
            var mockProductStorage = new ProductStorage(fixture.BeeManagerTestDb);

            int lengthBefore = mockProductStorage.GetProductsList().Count();

            int lastId = mockProductStorage.GetProductsList().LastOrDefault().Id;

            mockProductStorage.DeleteProductById(lastId);

            int lengthAfter = mockProductStorage.GetProductsList().Count();

            Assert.True(lengthBefore - 1 == lengthAfter);
        }

        [Fact]
        public void UpdateProductById_WhenMethodCalled_ThenProductNameUpdated()
        {
            var expected = new Product() { Id = 1, Name = "UpdatedName" };

            var mockProductStorage = new ProductStorage(fixture.BeeManagerTestDb);

            mockProductStorage.UpdateProduct(1, "UpdatedName");

            var actual = mockProductStorage.GetProductById(1);

            Assert.Equal(expected.Name, actual.Name);
        }


    }
}
