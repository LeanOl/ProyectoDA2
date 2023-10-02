using Domain;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Concrete
{
    public class productColorsManagement : GenericRepository<ProductColors>
    {


        public ProductColorsManagement(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<ProductColors> GetAllProductsColors()
        {
            return Context.Set<ProductColors>().ToList();
        }

        public Product GetProductById(int id)//creo que es inecesario para este sistema pero lo dejo ya que puede serlo
        {
            return Context.Set<Product>().Find(id);//resolver
        }

        public IEnumerable<string> GetColorByProductId(Guid productId)
        {
            return Context.Set<ProductColor>().Where(pc => pc.ProductId == productId).Select(pc => pc.Color).ToList();
        }


        public void InsertColor(ProductColor color)
        {
            _context.Set<ProductColor>().Add(color);
            _context.SaveChanges();
        }

        public void UpdateColor(ProductColor color)
        {
            _context.Set<ProductColor>().Update(color);
            _context.SaveChanges();
        }

        public void DeleteColor(int id)
        {
            var color = GetColorById(id);
            if (color != null)
            {
                _context.Set<ProductColor>().Remove(color);
                _context.SaveChanges();
            }
        }



    }




}