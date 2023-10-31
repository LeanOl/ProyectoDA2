using Domain;
using Logic;
using IData;
using System;
using System.Collections.Generic;
using ILogic;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductManagement _productManagement;

        public ProductLogic(IProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        public Product CreateProduct(Product product)
        {
            _productManagement.InsertProduct(product);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productManagement.GetAllProducts();
        }

        public Product GetProductById(Guid id)
        {
            return _productManagement.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            _productManagement.UpdateProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            _productManagement.DeleteProduct(id);
        }

        public IEnumerable<Product> GetFilteredProducts(string filter)
        {
            if (filter == "")
                return _productManagement.GetAllProducts();

            return _productManagement.GetFilteredProducts(filter);
        }
    }
}
