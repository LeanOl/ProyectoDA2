namespace APIModels.InputModels;

public class ShoppingCartProductRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}