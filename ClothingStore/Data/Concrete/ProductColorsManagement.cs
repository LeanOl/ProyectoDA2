using Domain;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Concrete
{
    public class productColorsManagement : GenericRepository<ProductColor>, IProductColorsManagement
    {


        public productColorsManagement(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<ProductColor> GetAllProductsColors()
        {
            return Context.Set<ProductColor>().ToList();
        }

       
        public IEnumerable<string> GetColorByProductId(Guid productId)
        {
            return Context.Set<ProductColor>().Where(pc => pc.ProductId == productId).Select(pc => pc.Color).ToList();
        }

        public ProductColor GetColorById(Guid id)
        {
            return Context.Set<ProductColor>().Find(id);
        }


        public void InsertColor(ProductColor color)
        {
            Context.Set<ProductColor>().Add(color);
            Context.SaveChanges();
        }

        public void UpdateColor(ProductColor color)
        {
            Context.Set<ProductColor>().Update(color);
            Context.SaveChanges();
        }

        public void DeleteColor(Guid id)
        {
            var color = GetColorById(id);
            if (color != null)
            {
                Context.Set<ProductColor>().Remove(color);
                Context.SaveChanges();
            }
        }



    }




}