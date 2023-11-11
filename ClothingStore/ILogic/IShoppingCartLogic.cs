using APIModels.InputModels;
using Domain;

namespace ILogic
{

    public interface IShoppingCartLogic
    {
        void ApplyBestPromotion(ShoppingCart shoppingCart);
        ShoppingCart UpdateShoppingCart(ShoppingCart received);
        ShoppingCart DeleteProduct(ShoppingCart cart,Guid productId);
    }
}