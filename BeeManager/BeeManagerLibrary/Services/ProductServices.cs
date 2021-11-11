using BeeManagerLibrary.Exceptions;
using BeeManagerLibrary.Models;
using BeeManagerLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeManagerLibrary.Services
{
    public class ProductServices : IProductServices
    {
        IProductStorage _productStorage;
        public ProductServices(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public string GetProductNameById(int id)
        {
            var productList = _productStorage.GetProductsList();

            if(productList.Find(f => f.Id == id) == null)
            {
                throw new ProductNotFoundException($"There is no product with ID number: {id}.");
            }

            string productName = productList.FirstOrDefault(p => p.Id == id).Name;

            return productName;
        }

        public int GetProductIdByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductNameIsNullOrWhiteSpaceException($"Entered string of productName is null, empty or white space");
            }

            var productList = _productStorage.GetProductsList();

            return productList.Find(p => p.Name == name).Id;
        }

        public void UpdateProduct(int id, string name)
        {
            _productStorage.UpdateProduct(id, name);
        }

        public void AddProduct(string productName)
        {
            _productStorage.AddProduct(productName);
        }

        public void DeleteProductById(int id)
        {
            _productStorage.DeleteProductById(id);
        }

        public List<Product> GetProductsList()
        {
           return _productStorage.GetProductsList();
        }

        public Product GetProductById(int id)
        {
            return _productStorage.GetProductById(id);
        }

    }
}
