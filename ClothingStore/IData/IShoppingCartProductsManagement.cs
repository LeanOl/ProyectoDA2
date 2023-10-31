using Domain;

namespace IData
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
