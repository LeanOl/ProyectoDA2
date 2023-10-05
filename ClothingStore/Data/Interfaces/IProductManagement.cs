using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductManagement
    {
       
            IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
        List<Product> GetProductByBrand(string brand);
        List<Product> GetProductByCategory(string category);
    
        
    }
}
