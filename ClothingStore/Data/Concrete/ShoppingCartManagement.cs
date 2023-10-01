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

        //retona todo el shopping cart del usuario
        public ShoppingCart GetShoppingCartById(Guid userId) {
            return Context.Set<ShoppingCart>()
                          .Include(s => s.ProductList)
                          .FirstOrDefault(s => s.IdUsuario == userId);
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

        //retorna la lista de productos del usuario
        public IEnumerable<Product> GetProductsInCart(Guid cartId)
        {
            var shoppingCart = GetShoppingCartById(cartId);
            return shoppingCart?.ProductList;
        }

    }
}
