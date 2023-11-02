using Domain;

namespace APIModels.InputModels;

public class ShoppingCartRequest
{
    public List<ShoppingCartProductRequest> Products { get; set; }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public ShoppingCart ToEntity()
    {
        return new ShoppingCart
        {
            IdCart = Id,
            UserId = UserId,
            ShoppingCartProducts = Products.ConvertAll(product =>
                new ShoppingCartProducts(Id, product.Product.ToEntity(product.Product.Id), product.Quantity))
        };
    }
}