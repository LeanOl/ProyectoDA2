using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.ShoppingCart;

namespace Data.Concrete
{
    public class ShoppingCartManagement : GenericRepository<ShoppingCart>
    {

        public ShoppingCartManagement(DbContext context) { 
        
            Context = context;
        }
        //revisar necesidad
        public IEnumerable<ShoppingCart> GetAllShoppingCarts() {
            return Context.Set<ShoppingCart>().Include(s => s.ProductList).ToList();

        }

        public ShoppingCart GetShoppingCartByUserId(Guid userId) {
            return Context.Set<ShoppingCart>().Where(sc => sc.IdUsuario == userId).ToList();
            
        }

        public void InsertShoppingCart(ShoppingCart shoppingCart)
        {
            Context.Set<ShoppingCart>().Add(shoppingCart);
            Context.SaveChanges();
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            Context.Set<ShoppingCart>().Update(shoppingCart);
            Context.SaveChanges();
        }

        public void DeleteShoppingCart(Guid cartId)
        {
            var shoppingCart = GetShoppingCartById(cartId);
            if (shoppingCart != null)
            {
                Context.Set<ShoppingCart>().Remove(shoppingCart);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProductsInCartByUserId(Guid cartId)
        {
            var shoppingCart = GetProductsInCartByUserId(cartId);
            return shoppingCart?.ProductList;
        }

    }
}
