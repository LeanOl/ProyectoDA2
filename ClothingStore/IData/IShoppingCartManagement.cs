using Domain;

namespace IData
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
