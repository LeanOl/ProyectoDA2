namespace Domain;

public class PurchaseProduct
{
    public Guid PurchaseId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public PurchaseProduct()
    {
    }

}