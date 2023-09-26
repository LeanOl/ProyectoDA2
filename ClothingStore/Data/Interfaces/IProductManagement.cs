using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface IProductManagement
    {
        public interface IProductyManagment
        {
            IEnumerable<Product> GetAllProducts();
            Product GetProductById(int id);
            void InsertProduct(Product product);
            void UpdateProduct(Product product);
            void DeleteProduct(int id);
            List<Product> GetProductByBrand(string brand);
            List<Product> GetProductByCategory(string category);

        }
    }
}
