using Domain;

namespace IData
{
    public interface IShoppingCartManagement
    {
        IEnumerable<ShoppingCart> GetAllShoppingCarts();
        ShoppingCart GetShoppingCartByUserId(Guid userId);
        void InsertShoppingCart(ShoppingCart shoppingCart);
        ShoppingCart UpdateShoppingCart(ShoppingCart shoppingCart);
        void ClearShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(Guid userId);
        IEnumerable<ShoppingCartProducts> GetProductsInCartByUserId(Guid userId);
        void DeleteProduct(Guid cartId, Guid productId);
    }
}
