namespace APIModels.InputModels;

public class DeleteShoppingCartProductRequest
{
    public ShoppingCartRequest Cart { get; set; }
    public Guid ProductId { get; set;}
}