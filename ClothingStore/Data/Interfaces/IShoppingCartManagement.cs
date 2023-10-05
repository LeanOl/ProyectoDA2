using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Interfaces
{
    public interface IShoppingCartManagement
    {
        IEnumerable<ShoppingCart> GetAllShoppingCarts();
        ShoppingCart GetShoppingCartByUserId(Guid userId);
        void InsertShoppingCart(ShoppingCart shoppingCart);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(Guid userId);
        IEnumerable<ShoppingCartProducts> GetProductsInCartByUserId(Guid userId);
    }
}
