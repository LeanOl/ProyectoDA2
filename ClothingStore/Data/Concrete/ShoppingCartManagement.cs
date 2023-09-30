using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Concrete
{
    public class ShoppingCartManagement : GenericRepository<ShoppingCartManagement>
    {

        public ShoppingCartManagement(DbContext context) { 
        
            Context = context;
        }

        public IEnumerable<ShoppingCart> GetAllShoppingCarts() {
            return Context.Set<ShoppingCart>().Include(s => s.ProductList).ToList();

        }

        public List<ShoppingCart> GetShoppingCartById(Guid userId) {
            return Context.Set<ShoppingCart>().Where(sc => sc.IdUsuario == userId).ToList();
        }


    }
}
