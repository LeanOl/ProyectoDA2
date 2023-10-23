using Domain;

namespace Data.Interfaces
{
    public interface IProductManagement : IGenericRepository<Product>
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
