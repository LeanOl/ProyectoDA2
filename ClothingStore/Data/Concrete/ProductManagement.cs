using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Concrete
{
    public class ProductManagement : GenericRepository<Product> //trae de generic repository
    {
        
       // private readonly DbContext _context; esto creo que no va
        
        public ProductManagement(DbContext context) 
        {
            Context = context;
        }
            
        public IEnumerable<Product> GetAllProducts()
        {
            return Context.Set<Product>().ToList();
        }

        public Product GetProductById(int id)//ahora es guid como se cambia esto ?
        {
            return Context.Set<Product>().Find(id);//resolver
        }

        public void InsertProduct(Product product)
        {
            Context.Set<Product>().Add(product);
            Context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Context.Set<Product>().Update(product);
            Context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                Context.Set<Product>().Remove(product);
                Context.SaveChanges();
            }
        }
        public List<Product> GetProductosByBrand(string brand)
        {
            return Context.Set<Product>().Where(p => p.Brand == brand).ToList();
        }

        public List<Product> GetProductosByCategory(string category)
        {
            return Context.Set<Product>().Where(p => p.Category == category).ToList();
        }

    }
}
