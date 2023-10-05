using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class ShoppingCartProductManagement : GenericRepository<ShoppingCartProducts>, IShoppingCartProductsManagement
    {
        public ShoppingCartProductManagement(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<ShoppingCartProducts> GetAllCartProducts()
        {
            return Context.Set<ShoppingCartProducts>().ToList();
        }


        public ShoppingCartProducts GetCartProductById(Guid id)
        {
            return Context.Set<ShoppingCartProducts>().Find(id);
        }

        public void InsertCartProduct(ShoppingCartProducts cartProduct)
        {
            Context.Set<ShoppingCartProducts>().Add(cartProduct);
            Save();
        }

        public void UpdateCartProduct(ShoppingCartProducts cartProduct)
        {
            Context.Set<ShoppingCartProducts>().Update(cartProduct);
            Save();
        }

        public void DeleteCartProduct(Guid id)
        {
            var cartProduct = GetCartProductById(id);
            if (cartProduct != null)
            {
                Context.Set<ShoppingCartProducts>().Remove(cartProduct);
                Save();
            }
        }

        public IEnumerable<ShoppingCartProducts> GetCartProductsByCartId(Guid cartId)
        {
            return Context.Set<ShoppingCartProducts>().Where(scp => scp.ShoppingCartId == cartId).ToList();
        }

    }
}
