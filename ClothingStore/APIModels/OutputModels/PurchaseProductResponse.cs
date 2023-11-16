using Domain;

namespace APIModels.OutputModels;

public class PurchaseProductResponse
{
    public Guid ProductId { get; set; }
    public ProductResponse Product { get; set; }
    public int Quantity { get; set; }

    public PurchaseProductResponse(PurchaseProduct purchaseProduct)
    {
        ProductId = purchaseProduct.ProductId;
        Product = new ProductResponse(purchaseProduct.Product);
        Quantity = purchaseProduct.Quantity;
    }
}