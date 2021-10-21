using System.Collections.Generic;
using System.Linq;

namespace BM_ConsoleUI
{
    public class ProductStorage : IProductStorage
    {
        public Product GetProductById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.Products.SingleOrDefault(p => p.Id == id);
            }
        }

        public void DeleteProductById(int id)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                var product = GetProductById(id);
                context.Products.Remove(product);

                context.SaveChanges();
            }
        }

        public void AddProduct(string productName)
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                context.Add(new Product()
                {
                    Name = productName
                });
                context.SaveChanges();
            }
        }

        public List<Product> GetProductsList()
        {
            using (var context = new BeeManagerContext(BeeManagerContext.GetDbContextOptions()))
            {
                return context.Products.ToList();
            }
        }
    }
}
