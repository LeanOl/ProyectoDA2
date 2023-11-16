namespace APIModels.InputModels;

public class ShoppingCartProductRequest
{
    public ProductRequest Product { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}