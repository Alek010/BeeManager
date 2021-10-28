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
            return _beeManagerContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            _beeManagerContext.Products.Remove(product);

            _beeManagerContext.SaveChanges();
        }

        public void AddProduct(string productName)
        {
            _beeManagerContext.Add(new Product()
            {
                Name = productName
            });
            _beeManagerContext.SaveChanges();
        }

        public List<Product> GetProductsList()
        {
            return _beeManagerContext.Products.ToList();
        }
    }
}
