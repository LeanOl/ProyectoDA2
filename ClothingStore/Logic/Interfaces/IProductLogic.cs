using Domain;
using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IProductLogic
    {
        Product CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
        IEnumerable<Product> GetFilteredProducts(string filter);
    }
}
