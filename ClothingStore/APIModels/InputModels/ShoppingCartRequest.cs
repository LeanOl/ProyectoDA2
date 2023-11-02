using Domain;

namespace APIModels.InputModels;

public class ShoppingCartRequest
{
    public List<ShoppingCartProductRequest> CartProducts { get; set; }
    public Guid UserId { get; set; }

    public ShoppingCart ToEntity()
    {
        Guid cartId = Guid.NewGuid();
        return new ShoppingCart
        {
            UserId = UserId,
            IdCart = cartId,
            ShoppingCartProducts = CartProducts.ConvertAll(product =>
                new ShoppingCartProducts(cartId, product.ProductId, product.Quantity))

        };
    }
}