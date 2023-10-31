﻿using Microsoft.EntityFrameworkCore;
using Domain;
using IData;


namespace Data.Concrete
{
    public class ShoppingCartManagement : GenericRepository<ShoppingCart>, IShoppingCartManagement
    {

        public ShoppingCartManagement(DbContext context) { 
        
            Context = context;
        }
        //revisar necesidad
        public IEnumerable<ShoppingCart> GetAllShoppingCarts() {
            return Context.Set<ShoppingCart>().Include(s => s.ShoppingCartProducts).ToList();

        }

        public ShoppingCart GetShoppingCartByUserId(Guid userId) {
            return Context.Set<ShoppingCart>().FirstOrDefault(sc => sc.UserId == userId);

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

        public void DeleteShoppingCart(Guid userId)
        {
            var shoppingCart = GetShoppingCartByUserId(userId);
            if (shoppingCart != null)
            {
                Context.Set<ShoppingCart>().Remove(shoppingCart);
                Context.SaveChanges();
            }
        }

        public IEnumerable<ShoppingCartProducts> GetProductsInCartByUserId(Guid cartId)
        {
            var shoppingCart = GetShoppingCartByUserId(cartId);
            return shoppingCart?.ShoppingCartProducts;
        }

    }
}
