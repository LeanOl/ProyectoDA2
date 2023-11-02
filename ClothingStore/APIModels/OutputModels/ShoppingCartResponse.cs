using Domain;

namespace APIModels.OutputModels;

public class ShoppingCartResponse
{
    public Guid IdCart { get; set; }
    public Guid UserId { get; set; }
    public List<ShoppingCartProductResponse> ShoppingCartProducts { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalPrice { get; set; }

    public ShoppingCartResponse(ShoppingCart shoppingCart)
    {
        IdCart = shoppingCart.IdCart;
        UserId = shoppingCart.UserId;
        ShoppingCartProducts = shoppingCart.ShoppingCartProducts.Select(product =>
                       new ShoppingCartProductResponse
                       {
                ProductId = product.ProductId,
                Quantity = product.Quantity
            }).ToList();
        TotalPrice = shoppingCart.TotalPrice;
        Discount = shoppingCart.Discount;
        FinalPrice = shoppingCart.FinalPrice;
    }

}