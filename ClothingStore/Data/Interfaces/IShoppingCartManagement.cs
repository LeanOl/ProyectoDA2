using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface IShoppingCartManagement
    {

        IEnumerable<ShoppingCart> GetAllShoppingCarts();
        ShoppingCart GetShoppingCartById(Guid cartId);
        void InsertShoppingCart(ShoppingCart shoppingCart);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(Guid cartId);
        IEnumerable<Product> GetProductsInCart(Guid cartId);

    }
}
