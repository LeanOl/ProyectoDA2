using Microsoft.EntityFrameworkCore;
using Domain;
using IData;


namespace Data
{
    public class ShoppingCartManagement : GenericRepository<ShoppingCart>, IShoppingCartManagement
    {

        public ShoppingCartManagement(DbContext context)
        {

            Context = context;
        }
        //revisar necesidad
        public IEnumerable<ShoppingCart> GetAllShoppingCarts()
        {
            return Context.Set<ShoppingCart>().Include(s => s.ShoppingCartProducts).ToList();

        }

        public ShoppingCart GetShoppingCartByUserId(Guid userId)
        {
            var shoppingCart = Context.Set<ShoppingCart>().
                Include(s => s.ShoppingCartProducts).
                FirstOrDefault(s => s.UserId.Equals(userId));
            if (shoppingCart != null)
            {
                foreach (var shoppingCartProduct in shoppingCart.ShoppingCartProducts)
                {
                    Context.Entry(shoppingCartProduct).Reference(scp => scp.Product).Load();
                    Context.Entry(shoppingCartProduct.Product).Collection(p => p.Colors).Load();
                }
            }

            return shoppingCart;

        }

        public void InsertShoppingCart(ShoppingCart shoppingCart)
        {
            Context.Set<ShoppingCart>().Add(shoppingCart);
            Context.SaveChanges();
        }

        public ShoppingCart UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            Context.Entry(shoppingCart).State = EntityState.Modified;
            List<ShoppingCartProducts> shoppingCartProducts = shoppingCart.ShoppingCartProducts;
            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                if (!Context.Set<ShoppingCartProducts>().Any(sp => sp.ProductId.Equals(shoppingCartProduct.ProductId) 
                                                                  && sp.ShoppingCartId.Equals(shoppingCartProduct.ShoppingCartId)))
                {
                    Context.Attach(shoppingCartProduct.Product);
                    Context.Set<ShoppingCartProducts>().Add(shoppingCartProduct);
                }
                else
                {
                    Context.Entry(shoppingCartProduct).State = EntityState.Modified;
                }
            }
            Context.SaveChanges();
            return shoppingCart;
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
