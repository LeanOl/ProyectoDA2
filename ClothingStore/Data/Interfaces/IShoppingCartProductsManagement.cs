using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IShoppingCartProductsManagement
    {
        IEnumerable<ShoppingCartProducts> GetAllCartProducts();
        ShoppingCartProducts GetCartProductById(Guid id);
        void InsertCartProduct(ShoppingCartProducts cartProduct);
        void UpdateCartProduct(ShoppingCartProducts cartProduct);
        void DeleteCartProduct(Guid id);
        IEnumerable<ShoppingCartProducts> GetCartProductsByCartId(Guid cartId);
    }
}
