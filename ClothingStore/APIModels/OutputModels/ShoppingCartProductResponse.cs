using Domain;

namespace APIModels.OutputModels;

public class ShoppingCartProductResponse
{
    public Guid ProductId { get; set; }
    public ProductResponse Product { get; set; }
    public int Quantity { get; set; }

    public ShoppingCartProductResponse(Product product, int quantity)
    {
        Product = new ProductResponse(product);
        Quantity = quantity;
        ProductId = product.Id;
    }
}