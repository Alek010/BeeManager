using BeeManagerLibrary.Exceptions;
using BeeManagerLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Repository
{
    public class ProductStorage : IProductStorage
    {
        private BeeManagerContext _beeManagerContext;
        public ProductStorage()
        {
            _beeManagerContext = new BeeManagerContext(BeeManagerContext.GetDbContextOptions());
        }

        public ProductStorage(BeeManagerContext beeManagerContext)
        {
            _beeManagerContext = beeManagerContext;
        }

        public Product GetProductById(int id)
        {
            var product = _beeManagerContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new ProductNotFoundException(ExceptionMessage.ProductNotFound(id));
            }

            return product;
        }

        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);

            if (product == null)
            {
                throw new ProductNotFoundException(ExceptionMessage.ProductNotFound(id));
            }

            _beeManagerContext.Products.Remove(product);

            _beeManagerContext.SaveChanges();
        }

        public void AddProduct(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ProductNameIsNullOrWhiteSpaceException(ExceptionMessage.ProductNameIsNullOrWhiteSpace());
            }

            _beeManagerContext.Add(new Product()
            {
                Name = productName
            });

            _beeManagerContext.SaveChanges();
        }

        public void UpdateProduct(int id, string productName)
        {
            var product = GetProductById(id);

            product.Name = productName;

            if (product == null)
            {
                throw new ProductNotFoundException(ExceptionMessage.ProductNotFound(id));
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ProductNameIsNullOrWhiteSpaceException(ExceptionMessage.ProductNameIsNullOrWhiteSpace());
            }

            _beeManagerContext.Update(product);

            _beeManagerContext.SaveChanges();
        }

        public List<Product> GetProductsList()
        {
            return _beeManagerContext.Products.ToList();
        }

        public int GetProductIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductNameIsNullOrWhiteSpaceException(ExceptionMessage.ProductNameIsNullOrWhiteSpace());
            }

            return _beeManagerContext.Products.First(p => p.Name == name).Id;
        }
    }
}
