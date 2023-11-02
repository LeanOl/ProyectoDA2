using Domain;

namespace APIModels.OutputModels;

public class ShoppingCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<ShoppingCartProductResponse>? Products { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? Discount { get; set; }
    public decimal? FinalPrice { get; set; }
    public string ? PromotionName { get; set; }

    public ShoppingCartResponse(ShoppingCart shoppingCart)
    {
        Id = shoppingCart.IdCart;
        UserId = shoppingCart.UserId;
        if (shoppingCart.ShoppingCartProducts != null)
        {
            Products = shoppingCart.ShoppingCartProducts?.Select(product =>
                new ShoppingCartProductResponse(product.Product, product.Quantity)).ToList();
        }
        else
        {
            Products = new List<ShoppingCartProductResponse>();
        }
        TotalPrice = shoppingCart.TotalPrice;
        Discount = shoppingCart.Discount;
        FinalPrice = shoppingCart.FinalPrice;
        PromotionName = shoppingCart.PromotionName;
    }

}