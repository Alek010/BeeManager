using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BM_ConsoleUI.Tests
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

            Assert.True(newName == newProduct);
        }
    }
}
