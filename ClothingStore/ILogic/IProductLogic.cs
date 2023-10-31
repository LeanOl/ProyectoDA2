using Domain;

namespace ILogic
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
