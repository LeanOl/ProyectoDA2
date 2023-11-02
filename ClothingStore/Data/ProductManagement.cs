﻿using Domain;
using IData;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class ProductManagement : GenericRepository<Product>, IProductManagement
    {

        public ProductManagement(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Context.Set<Product>().Include(p => p.Colors);
        }

        public Product GetProductById(Guid id)
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

        public void DeleteProduct(Guid id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                Context.Set<Product>().Remove(product);
                Context.SaveChanges();
            }
        }
        public List<Product> GetProductByBrand(string brand)
        {
            return Context.Set<Product>().Where(p => p.Brand == brand).ToList();
        }

        public List<Product> GetProductByCategory(string category)
        {
            return Context.Set<Product>().Where(p => p.Category == category).ToList();
        }

        public IEnumerable<Product> GetFilteredProducts(string filter)
        {
            return Context.Set<Product>().Include(p => p.Colors).Where(p => p.Name.Contains(filter) ||
                                                     p.Brand.Equals(filter) ||
                                                     p.Category.Equals(filter)).ToList();
        }
    }
}