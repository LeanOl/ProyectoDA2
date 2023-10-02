using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IShoppingCartManagement
    {
        IEnumerable<ShoppingCart> GetAllShoppingCarts();
        ShoppingCart GetShoppingCartByUserId(Guid userId);
        void InsertShoppingCart(ShoppingCart shoppingCart);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(Guid userId);
        IEnumerable<Product> GetProductsInCartByUserId(Guid userId);
    }
}
